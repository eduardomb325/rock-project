using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IWeightService<T> where T : class
    {
        List<T> SaveWeightList(List<T> weightList);

        List<T> GetWeightList();
    }
}
