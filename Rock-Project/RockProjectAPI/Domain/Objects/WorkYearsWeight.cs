using RockProjectAPI.Domain.Objects.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RockProjectAPI.Domain.Objects
{
    public class WorkYearsWeight : IWeight
    {
        [Key]
        public int Id { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int Weight { get; set; }

        public WorkYearsWeight()
        {

        }

        public WorkYearsWeight(int yearMin, int yearMax, int weight)
        {
            YearMin = yearMin;
            YearMax = yearMax;
            Weight = weight;
        }

        public bool IsYearIsInThisWeight(double year)
        {
            bool isYearIsInThisWeight = false;

            if (YearMin.Equals(YearMax))
            {
                isYearIsInThisWeight = year > YearMax;
            }
            else if (year >= YearMin && year <= YearMax)
            {
                isYearIsInThisWeight = true;
            }
            return isYearIsInThisWeight;
        }
    }
}
