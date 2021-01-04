using Microsoft.Extensions.Configuration;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services
{
    public class ProfitService : IProfitService
    {
        private string MinimumSalary;

        private IEmployeeRepository _employeeRepository;
        private IConfiguration Configuration;
        private IWeightRepository<OccupationAreaWeight> _occupationAreaWeightRepository;
        private IWeightRepository<SalaryWeight> _salaryWeightRepository;
        private IWeightRepository<WorkYearsWeight> _workYearsWeightRepository;

        public ProfitService(
                IEmployeeRepository employeeRepository,
                IWeightRepository<OccupationAreaWeight> occupationAreaWeightRepository,
                IWeightRepository<SalaryWeight> salaryWeightRepository,
                IWeightRepository<WorkYearsWeight> workYearsWeightRepository
            )
        {
            MinimumSalary = Configuration["MinimumSalary"];

            _employeeRepository = employeeRepository;
            _occupationAreaWeightRepository = occupationAreaWeightRepository;
            _salaryWeightRepository = salaryWeightRepository;
            _workYearsWeightRepository = workYearsWeightRepository;
        }

        public Profit GetProfit(double expectedProfit)
        {
            List<Employee> employeeList = _employeeRepository.GetEmployees();

            List<OccupationAreaWeight> occupationAreaWeightList = _occupationAreaWeightRepository.GetWeightList();

            List<SalaryWeight> salaryWeightList = _salaryWeightRepository.GetWeightList();

            List<WorkYearsWeight> workYearList = _workYearsWeightRepository.GetWeightList();


            List<EmployeeParticipation> participationList = new List<EmployeeParticipation>();

            foreach(Employee employee in employeeList)
            {
                DateTime employeeAdmission = DateTime.Parse(employee.AdmissionDate);

                string actuationArea = employee.Area;
                double convertedSalary = double.Parse(employee.Salary.Replace("R$ ", ""));
                double convertedMinimumSalary = double.Parse(MinimumSalary);

                int occupationAreaWeight = occupationAreaWeightList.Find(x => x.OccupationArea.Equals(actuationArea)).Weight;
                int salaryWeight = salaryWeightList.Find(x => x.IsSalaryIsInThisWeight(convertedMinimumSalary, convertedSalary, employee.Area);
                int workYearsWeight = workYearList.Find(x => x.IsYearIsInThisWeight(employeeAdmission.Year).Equals(true)).Weight;

                EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                    employee, 
                    occupationAreaWeight, 
                    salaryWeight, 
                    workYearsWeight
                );

                participationList.Add(employeeParticipation);
            }

            Profit profit = new Profit(participationList, expectedProfit);

            return profit;
        }
    }
}
