using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services;
using Microsoft.Extensions.Configuration;
using RockProjectAPI.Domain.Services.Interfaces;
using RockProjectAPI.Domain.Objects;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace UnitTests.Domain.Services
{
    public class ProfitServiceUnitTest
    {
        private Mock<IConfiguration> _configuration;

        private Mock<IEmployeeRepository> _employeeRepository;

        private readonly Mock<IWeightService<OccupationAreaWeight>> OccupationAreaService;
        private readonly Mock<IWeightService<SalaryWeight>> SalaryWeightService;
        private readonly Mock<IWeightService<WorkYearsWeight>> WorkYearsWeightService;

        private ILogger<ProfitService> _logger;

        private ProfitService ProfitService;

        public ProfitServiceUnitTest()
        {
            _configuration = new Mock<IConfiguration>();
            _employeeRepository = new Mock<IEmployeeRepository>();

            OccupationAreaService = new Mock<IWeightService<OccupationAreaWeight>>();
            SalaryWeightService = new Mock<IWeightService<SalaryWeight>>();
            WorkYearsWeightService = new Mock<IWeightService<WorkYearsWeight>>();

            _logger = GetLogger();
        }

        [Fact]
        public void When_Has_Employees_Calculate_Profit()
        {

            string id1 = "1234";
            string occupationArea1 = "Diretoria";
            string name1 = "Joao";
            string position1 = "Diretor";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, name1, position1, admissionDate1, salary1);

            string id2 = "12345";
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2019-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            string id3 = "23241";
            string occupationArea3 = "Serviços Gerais";
            string name3 = "Julia";
            string position3 = "Arquiteta";
            string admissionDate3 = "2017-05-25";
            string salary3 = "R$ 3.500,00";

            Employee employee3 = new Employee(id3, occupationArea3, name3, position3, admissionDate3, salary3);

            string id4 = "15949";
            string occupationArea4 = "Relacionamento com o Cliente";
            string name4 = "Joana";
            string position4 = "Supervisora";
            string admissionDate4 = "2010-04-20";
            string salary4 = "R$ 6.000,00";

            Employee employee4 = new Employee(id4, occupationArea4, name4, position4, admissionDate4, salary4);

            string id5 = "33221";
            string occupationArea5 = "Contabilidade";
            string name5 = "Joana";
            string position5 = "Estagiário";
            string admissionDate5 = "2019-10-06";
            string salary5 = "R$ 2.000,00";

            Employee employee5 = new Employee(id5, occupationArea5, name5, position5, admissionDate5, salary5);

            List<Employee> employeeList = new List<Employee>();

            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);
            employeeList.Add(employee5);

            _configuration.Setup(x => x["MinimumSalary"]).Returns("1088");

            _employeeRepository.Setup(x => x.GetEmployees()).Returns(employeeList);

            OccupationAreaService.Setup(x => x.GetWeightList()).Returns(GenerateStarterOccupationAreaWeightList());

            SalaryWeightService.Setup(x => x.GetWeightList()).Returns(GenerateStarterSalaryWeightList());

            WorkYearsWeightService.Setup(x => x.GetWeightList()).Returns(GenerateStarterWorkYearsWeightList());

            ProfitService = new ProfitService(
                    _employeeRepository.Object,
                    _configuration.Object,
                    _logger,
                    OccupationAreaService.Object,
                    SalaryWeightService.Object,
                    WorkYearsWeightService.Object
                );

            double expectedProfit = 10000;

            Profit profit = ProfitService.GetProfit(expectedProfit);

            profit.EmployeesTotal.Should().Be("5");

            profit.Participations.Find(x => x.Id.Equals(employee1.Id)).ValorParticipacao.Should().Be("R$ 48.000,00");
            profit.Participations.Find(x => x.Id.Equals(employee2.Id)).ValorParticipacao.Should().Be("R$ 96.000,00");
            profit.Participations.Find(x => x.Id.Equals(employee3.Id)).ValorParticipacao.Should().Be("R$ 126.000,00");
            profit.Participations.Find(x => x.Id.Equals(employee4.Id)).ValorParticipacao.Should().Be("R$ 240.000,00");
            profit.Participations.Find(x => x.Id.Equals(employee5.Id)).ValorParticipacao.Should().Be("R$ 96.000,00");

            profit.CalculatedProfit.Should().Be("R$ 606.000,00");
            profit.ExpectedProfit.Should().Be("R$ 10.000,00");
            profit.BalanceProfit.Should().Be("-R$ 596.000,00");
        }


        public List<OccupationAreaWeight> GenerateStarterOccupationAreaWeightList()
        {
            List<OccupationAreaWeight> occupationAreaWeightList = new List<OccupationAreaWeight>();

            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 1, OccupationArea = "Diretoria", Weight = 1 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 2, OccupationArea = "Contabilidade", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 3, OccupationArea = "Financeiro", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 4, OccupationArea = "Tecnologia", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 5, OccupationArea = "Serviços Gerais", Weight = 3 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 6, OccupationArea = "Relacionamento com o Cliente", Weight = 5 });

            return occupationAreaWeightList;
        }

        public List<SalaryWeight> GenerateStarterSalaryWeightList()
        {
            List<SalaryWeight> salaryWeightList = new List<SalaryWeight>();

            salaryWeightList.Add(new SalaryWeight { Id = 2, SalaryMin = 1, SalaryMax = 3, OccupationPositionException = new List<string> { "Estagiário" }, Weight = 1 });
            salaryWeightList.Add(new SalaryWeight { Id = 3, SalaryMin = 3, SalaryMax = 5, Weight = 2 });
            salaryWeightList.Add(new SalaryWeight { Id = 4, SalaryMin = 5, SalaryMax = 8, Weight = 3 });
            salaryWeightList.Add(new SalaryWeight { Id = 5, SalaryMin = 8, SalaryMax = 8, Weight = 5 });

            return salaryWeightList;
        }

        public List<WorkYearsWeight> GenerateStarterWorkYearsWeightList()
        {
            List<WorkYearsWeight> workYearWeightList = new List<WorkYearsWeight>();

            workYearWeightList.Add(new WorkYearsWeight { Id = 1, YearMin = 0, YearMax = 1, Weight = 1 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 2, YearMin = 1, YearMax = 3, Weight = 2 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 3, YearMin = 3, YearMax = 8, Weight = 3 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 4, YearMin = 8, YearMax = 8, Weight = 5 });

            return workYearWeightList;
        }

        private ILogger<ProfitService> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<ProfitService>();

            return logger;
        }
    }
}
