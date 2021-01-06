using System.Collections.Generic;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IWeightService<T> where T : class
    {
        List<T> SaveWeightList(List<T> weightList);

        List<T> GetWeightList();
    }
}
