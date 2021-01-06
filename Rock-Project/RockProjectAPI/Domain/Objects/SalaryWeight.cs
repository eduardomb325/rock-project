using RockProjectAPI.Domain.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects
{
    public class SalaryWeight : IWeight
    {
        [Key]
        public int Id { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public int Weight { get; set; }
        public List<string> OccupationPositionException { get; set; } = new List<string>();

        public SalaryWeight()
        {

        }

        public SalaryWeight(int salaryMin, int salaryMax, int weight, List<string> occupationPositionException)
        {
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            Weight = weight;
            OccupationPositionException = occupationPositionException;
        }

        public bool IsSalaryIsInThisWeight(double baseSalary, double salary, string occupation)
        {
            bool isSalaryIsThisWeight = false;

            double salaryMin = baseSalary * SalaryMin;
            double salaryMax = baseSalary * SalaryMax;

            if (SalaryMin.Equals(SalaryMax))
            {
                isSalaryIsThisWeight = salary > salaryMax;
            }
            else if (OccupationPositionException.Contains(occupation) || (salary >= salaryMin && salary <= salaryMax))
            {
                isSalaryIsThisWeight = true;
            }

            return isSalaryIsThisWeight;
        }
    }
}
