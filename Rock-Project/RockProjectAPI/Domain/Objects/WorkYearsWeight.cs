using RockProjectAPI.Domain.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects
{
    public class WorkYearsWeight : IWeight
    {
        [Key]
        public int Id { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int Weight { get; set; }

        public WorkYearsWeight(int yearMin, int yearMax, int weight)
        {
            YearMin = yearMin;
            YearMax = yearMax;
            Weight = weight;
        }

        public WorkYearsWeight()
        {

        }
    }
}
