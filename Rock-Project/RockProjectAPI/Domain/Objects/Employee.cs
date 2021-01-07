using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RockProjectAPI.Domain.Objects
{
    public class Employee : EmployeeBase
    {
        [Required]
        [JsonPropertyName("area")]
        public string Area { get; set; }

        [Required]
        [JsonPropertyName("cargo")]
        public string Position { get; set; }

        [Required]
        [JsonPropertyName("data_de_admissao")]
        public string AdmissionDate { get; set; }

        [Required]
        [JsonPropertyName("salario_bruto")]
        public string Salary { get; set; }

        public Employee(string id, string occupationArea, string name, string position, string admissionalDate, string salary)
        {
            Id = id;
            Area = occupationArea;
            Name = name;
            Position = position;
            AdmissionDate = admissionalDate;
            Salary = salary;
        }

        public Employee()
        {

        }

        public bool IsValidAdmissionDate()
        {
            bool isValidAdmissionDate = false;

            try
            {
                DateTime convertedDateTime = DateTime.Parse(AdmissionDate);

                if (convertedDateTime < DateTime.Now)
                {
                    isValidAdmissionDate = true;
                }
            }
            catch (Exception)
            {
            }

            return isValidAdmissionDate;
        }

        public bool IsValidEmployee()
        {
            bool isValidEmployee = false;

            if (IsValidSalary() 
                    && IsValidAdmissionDate() 
                    && !string.IsNullOrEmpty(Area)
                    && !string.IsNullOrEmpty(Id)
                    && !string.IsNullOrEmpty(Name)
                    && !string.IsNullOrEmpty(Position)
                )
            {
                isValidEmployee = true;
            }

            return isValidEmployee;
        }

        private bool IsValidSalary()
        {
            bool isValidSalary = false;

            try
            {
                double convertedSalary = double.Parse(Salary.Replace("R$ ", ""));

                if (convertedSalary > 1)
                {
                    isValidSalary = true;
                }
            }
            catch (Exception)
            {
                
            }

            return isValidSalary;
        }

        public override string ToString()
        {
            return string.Format(
                "Id: {0} - " +
                "Name: {1} - " +
                "AdmissionDate {2} -" +
                "Area: {3} - " +
                "Position: {4} - " +
                "Salary: {5}", Id, Name, AdmissionDate, Area, Position, Salary);
        }
    }
}
