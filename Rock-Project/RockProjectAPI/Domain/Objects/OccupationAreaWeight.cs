using RockProjectAPI.Domain.Objects.Interfaces;
using System.ComponentModel.DataAnnotations;

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
