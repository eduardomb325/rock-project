using RockProjectAPI.Domain.Objects.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization;

namespace RockProjectAPI.Domain.Objects
{
    public class EmployeeParticipation : EmployeeBase
    {
        [JsonPropertyName("valor_da_participacao")]
        public string ValorParticipacao { get; set; }

        public EmployeeParticipation(Employee employee, int occupationAreaWeight, int salaryWeight, int workYearsWeight)
        {
            Id = employee.Id;
            Name = employee.Name;
            ValorParticipacao = CalculateParticipationValue(employee.Salary, occupationAreaWeight, salaryWeight, workYearsWeight);
        }

        public EmployeeParticipation()
        {

        }

        public string CalculateParticipationValue(string salary, int occupationAreaWeight, int salaryWeight, int workYearsWeight)
        {
            double convertedSalary = double.Parse(salary.Replace("R$ ", ""));
            double admissionTimeCalculate = convertedSalary * workYearsWeight;
            double occupationAreaCalculate = convertedSalary * occupationAreaWeight;
            double salaryCalculate = (admissionTimeCalculate + occupationAreaCalculate) / salaryWeight;

            double participationValue = salaryCalculate * 12;

            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", participationValue);
        }
    }
}
