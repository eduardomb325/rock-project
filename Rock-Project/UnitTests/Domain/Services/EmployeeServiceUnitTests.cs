using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Objects.DTOs;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Domain.Services
{
    public class EmployeeServiceUnitTests
    {
        public Mock<IEmployeeRepository> employeeRepositoryMock;
        public ILogger<EmployeeService> logger;

        public EmployeeService employeeService;

        public EmployeeServiceUnitTests()
        {
            employeeRepositoryMock = new Mock<IEmployeeRepository>();
            logger = GetLogger();

            employeeService = new EmployeeService(employeeRepositoryMock.Object, logger);
        }

        [Fact]
        public void When_Try_To_Get_Employees_Return_Employees()
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
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.GetEmployees()).Returns(employeesList);

            List<Employee> responseList = employeeService.GetEmployeesService();

            responseList.Count.Should().Be(2);
            responseList.Equals(employeesList).Should().BeTrue();
        }

        [Fact]
        public void When_Try_Save_Employees_Corrects_Return_Correct_Items_Inserted()
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
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(2);
            responseList.EmployeesNotRegistered.Count.Should().Be(0);

            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_Without_Id_Return_EmployeeResponseDTO_Correct()
        {
            string occupationArea1 = "Diretoria";
            string name1 = "Joao";
            string position1 = "Diretor";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee("", occupationArea1, name1, position1, admissionDate1, salary1);

            string id2 = "12345";
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);

            responseList.EmployeesNotRegistered.Find(x => x.Name.Equals(name1)).Should().Be(employee1);
            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_Without_Name_Return_EmployeeResponseDTO_Correct()
        {
            string id1 = "1234";
            string occupationArea1 = "Diretoria";
            string position1 = "Diretor";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, "", position1, admissionDate1, salary1);

            string id2 = "12345"; 
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);

            responseList.EmployeesNotRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_Without_Position_Return_EmployeeResponseDTO_Correct()
        {
            string id1 = "1234";
            string name1 = "Joao";
            string occupationArea1 = "Diretoria";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, name1, "", admissionDate1, salary1);

            string id2 = "12345";
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);

            responseList.EmployeesNotRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_With_Future_AdmissionDate_Return_EmployeeResponseDTO_Correct()
        {
            string id1 = "1234";
            string name1 = "Joao";
            string position1 = "Diretor";
            string occupationArea1 = "Diretoria";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, name1, position1, admissionDate1, salary1);

            string id2 = "12345";
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2100-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);

            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
            responseList.EmployeesNotRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_Without_AdmissionDate_Return_EmployeeResponseDTO_Correct()
        {
            string id1 = "1234";
            string name1 = "Joao";
            string position1 = "Diretor";
            string occupationArea1 = "Diretoria";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, name1, position1, admissionDate1, salary1);

            string id2 = "12345";
            string occupationArea2 = "Contabilidade";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, occupationArea2, name2, position2, "", salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);

            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
            responseList.EmployeesNotRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
        }

        [Fact]
        public void When_Try_Save_Employees_1Correct_And_1_Without_Occupation_Area_Return_EmployeeResponseDTO_Correct()
        {
            string id1 = "1234";
            string occupationArea1 = "Diretoria";
            string name1 = "Joao";
            string position1 = "Diretor";
            string admissionDate1 = "2020-10-20";
            string salary1 = "R$ 10.000,00";

            Employee employee1 = new Employee(id1, occupationArea1, name1, position1, admissionDate1, salary1);

            string id2 = "12345";
            string name2 = "Victor";
            string position2 = "Auxiliar";
            string admissionDate2 = "2017-05-25";
            string salary2 = "R$ 2.000,00";

            Employee employee2 = new Employee(id2, "", name2, position2, admissionDate2, salary2);

            List<Employee> employeesList = new List<Employee>();

            employeesList.Add(employee1);
            employeesList.Add(employee2);

            employeeRepositoryMock.Setup(x => x.SaveEmployees(It.IsAny<List<Employee>>())).Returns(employeesList);

            EmployeeRegisterDTO responseList = employeeService.SaveEmployeesService(employeesList);

            responseList.EmployeesRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Count.Should().Be(1);
            responseList.EmployeesNotRegistered.Find(x => x.Id.Equals(id2)).Should().Be(employee2);
            responseList.EmployeesRegistered.Find(x => x.Id.Equals(id1)).Should().Be(employee1);
        }


        private ILogger<EmployeeService> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<EmployeeService>();

            return logger;
        }
    }
}
