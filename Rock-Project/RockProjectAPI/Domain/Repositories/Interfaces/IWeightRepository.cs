﻿using System.Collections.Generic;

namespace RockProjectAPI.Domain.Repositories.Interfaces
{
    public interface IWeightRepository<T> where T : class
    {
        int CountWeightList();
        List<T> GetWeightList();
        List<T> SaveWeightList(List<T> weightList);
    }
}
