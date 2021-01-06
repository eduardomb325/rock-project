using RockProjectAPI.Domain.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects
{
    public class OccupationAreaWeight : IWeight
    {
        [Key]
        public int Id { get; set; }
        public string OccupationArea { get; set; }
        public int Weight { get; set; }

        public OccupationAreaWeight()
        {

        }

        public OccupationAreaWeight(string occupationArea, int weight)
        {
            OccupationArea = occupationArea;
            Weight = weight;
        }

    }
}
