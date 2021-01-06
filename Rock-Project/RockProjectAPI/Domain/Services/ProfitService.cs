using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockProjectAPI.Domain.Services
{
    public class ProfitService : IProfitService
    {
        private string MinimumSalary;

        private IEmployeeRepository _employeeRepository;
        private IConfiguration Configuration;
        private ILogger<ProfitService> _logger;

        private readonly IWeightService<OccupationAreaWeight> OccupationAreService;
        private readonly IWeightService<SalaryWeight> SalaryWeightService;
        private readonly IWeightService<WorkYearsWeight> WorkYearsWeightService;

        public ProfitService(
                IEmployeeRepository employeeRepository,
                IConfiguration configuration,
                ILogger<ProfitService> logger,
                IWeightService<OccupationAreaWeight> occupationAreaWeightService,
                IWeightService<SalaryWeight> salaryWeightRepositoryService,
                IWeightService<WorkYearsWeight> workYearsWeightService
            )
        {
            Configuration = configuration;
            MinimumSalary = Configuration["MinimumSalary"];

            _employeeRepository = employeeRepository;
            _logger = logger;

            OccupationAreService = occupationAreaWeightService;
            SalaryWeightService = salaryWeightRepositoryService;
            WorkYearsWeightService = workYearsWeightService;
        }

        public Profit GetProfit(double expectedProfit)
        {
            _logger.LogInformation("Service: GetProfit - Start");

            List<Employee> employeeList = _employeeRepository.GetEmployees();

            List<OccupationAreaWeight> occupationAreaWeightList = OccupationAreService.GetWeightList();

            List<SalaryWeight> salaryWeightList = SalaryWeightService
                                                        .GetWeightList()
                                                        .OrderBy(x => x.Id)
                                                        .ToList();

            List<WorkYearsWeight> workYearList = WorkYearsWeightService.GetWeightList();


            List<EmployeeParticipation> participationList = new List<EmployeeParticipation>();

            foreach (Employee employee in employeeList)
            {
                DateTime employeeAdmission = DateTime.Parse(employee.AdmissionDate);

                string actuationArea = employee.Area;
                double convertedSalary = double.Parse(employee.Salary.Replace("R$ ", ""));
                double convertedMinimumSalary = double.Parse(MinimumSalary);

                int occupationAreaWeight = occupationAreaWeightList.Find(x => x.OccupationArea.Equals(actuationArea)).Weight;

                int salaryWeight = salaryWeightList
                                        .Find(x => x
                                                    .IsSalaryIsInThisWeight(convertedMinimumSalary, convertedSalary, employee.Position)
                                                    .Equals(true)
                                         )
                                        .Weight;

                int workYearsWeight = workYearList
                                                .Find(x => x.IsYearIsInThisWeight(employeeAdmission.Year)
                                                .Equals(true))
                                                .Weight;

                EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                    employee,
                    occupationAreaWeight,
                    salaryWeight,
                    workYearsWeight
                );

                participationList.Add(employeeParticipation);
            }

            Profit profit = new Profit(participationList, expectedProfit);

            _logger.LogInformation("Service: GetProfit - Finish - Generated Profit: " + profit.ToString());

            return profit;
        }
    }
}
