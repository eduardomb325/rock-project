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
        public double SalaryMin { get; set; }
        public double SalaryMax { get; set; }
        public int Weight { get; set; }
        public List<string> OccupationAreaException { get; set; } = new List<string>();

        public SalaryWeight(double salaryMin, double salaryMax, int weight, List<string> occupationAreaException)
        {
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            Weight = weight;
            OccupationAreaException = occupationAreaException;
        }

        public SalaryWeight()
        {

        }
    }
}
