using System;
using System.Collections.Generic;
using System.Text;
using RockProjectAPI.Domain.Objects;
using System;
using Xunit;
using FluentAssertions;

namespace UnitTests.Domain.Objects
{
    public class EmployeeParticipationUnitTests
    {
        [Fact]
        public void When_Occupation_Area_1_Salary_Weight_1_WorkYears_1_Validate_Profit_Calculation()
        {
            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor";
            string admissionDate = "2021-01-01";
            string salary = "R$ 10.000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            int occupationAreaWeight = 1;
            int salaryWeight = 1;
            int workYearsWeight = 1;

            EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                employee, 
                occupationAreaWeight, 
                salaryWeight, 
                workYearsWeight
            );

            double convertedEmployeeParticipation = double.Parse(employeeParticipation.ValorParticipacao.Replace("R$ ", ""));

            convertedEmployeeParticipation.Should().Be(240000);
        }


        [Fact]
        public void When_Occupation_Area_2_Salary_Weight_2_WorkYears_2_Validate_Profit_Calculation()
        {
            string id = "1234";
            string occupationArea = "Tecnologia";
            string name = "Joao";
            string position = "Desenvolvedor";
            string admissionDate = "2019-10-20";
            string salary = "R$ 3.500,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            int occupationAreaWeight = 2;
            int salaryWeight = 2;
            int workYearsWeight = 2;

            EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                employee,
                occupationAreaWeight,
                salaryWeight,
                workYearsWeight
            );

            double convertedEmployeeParticipation = double.Parse(employeeParticipation.ValorParticipacao.Replace("R$ ", ""));

            convertedEmployeeParticipation.Should().Be(84000);
        }

        [Fact]
        public void When_Occupation_Area_3_Salary_Weight_3_WorkYears_3_Validate_Profit_Calculation()
        {
            string id = "1234";
            string occupationArea = "Serviços Gerais";
            string name = "Joana";
            string position = "Eletricista";
            string admissionDate = "2017-10-20";
            string salary = "R$ 6000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            int occupationAreaWeight = 3;
            int salaryWeight = 3;
            int workYearsWeight = 3;

            EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                employee,
                occupationAreaWeight,
                salaryWeight,
                workYearsWeight
            );

            double convertedEmployeeParticipation = double.Parse(employeeParticipation.ValorParticipacao.Replace("R$ ", ""));
             
            convertedEmployeeParticipation.Should().Be(144000);
        }

        [Fact]
        public void When_Occupation_Area_5_Salary_Weight_5_WorkYears_5_Validate_Profit_Calculation()
        {
            string id = "1234";
            string occupationArea = "Diretoria";
            string name = "Joao";
            string position = "Diretor de Finanças";
            string admissionDate = "2010-10-20";
            string salary = "R$ 12000,00";

            Employee employee = new Employee(id, occupationArea, name, position, admissionDate, salary);

            int occupationAreaWeight = 5;
            int salaryWeight = 5;
            int workYearsWeight = 5;

            EmployeeParticipation employeeParticipation = new EmployeeParticipation(
                employee,
                occupationAreaWeight,
                salaryWeight,
                workYearsWeight
            );

            double convertedEmployeeParticipation = double.Parse(employeeParticipation.ValorParticipacao.Replace("R$ ", ""));

            convertedEmployeeParticipation.Should().Be(288000);
        }
    }
}
