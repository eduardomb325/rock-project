using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using RockProjectAPI.Domain.Objects;
using System;
using Xunit;

namespace UnitTests.Domain.Objects
{
    public class EmployeeUnitTests
    {
        [Fact]
        public void When_Try_To_Validate_Employee_And_Its_Correct_Return_True()
        {
            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "2020-10-20";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeTrue();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Id_Is_Empty_Return_False()
        {
            string id = "";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "2020-10-20";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Occupation_Area_Is_Empty_Return_False()
        {
            string id = "1234";
            string occupationArea = "";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "2020-10-20";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Name_Is_Empty_Return_False()
        {
            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "";
            string position = "Diretor";
            string admissionDate = "2020-10-20";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Position_Is_Empty_Return_False()
        {
            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "";
            string admissionDate = "2020-10-20";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Admission_Date_Is_Empty_Return_False()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<Employee>();

            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(logger);

            employee.Id = id;
            employee.Area = occupationArea;
            employee.Name = name;
            employee.Position = position;
            employee.AdmissionDate = admissionDate;
            employee.Salary = salary;

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }

        [Fact]
        public void When_Try_To_Validate_Employee_And_Salary_Is_Empty_Return_False()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<Employee>();

            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "2020-12-20";
            string salary = "";

            Employee employee = new Employee(logger);

            employee.Id = id;
            employee.Area = occupationArea;
            employee.Name = name;
            employee.Position = position;
            employee.AdmissionDate = admissionDate;
            employee.Salary = salary;

            bool isValidEmployee = employee.IsValidEmployee();

            isValidEmployee.Should().BeFalse();
        }
    }
}
