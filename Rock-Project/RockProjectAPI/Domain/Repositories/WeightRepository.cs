using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Context;
using RockProjectAPI.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockProjectAPI.Domain.Repositories
{
    public class WeightRepository<T> : IWeightRepository<T> where T : class
    {
        private readonly ApiContext _context;
        private readonly ILogger<WeightRepository<T>> _logger;

        public WeightRepository(ApiContext context, ILogger<WeightRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }


        public List<T> GetWeightList()
        {
            _logger.LogInformation("Repository: GetSalaryWeights - Start");

            List<T> weightList = _context.Set<T>().ToList();

            _logger.LogInformation("Repository: GetSalaryWeights - Finish");

            return weightList;
        }

        public List<T> SaveWeightList(List<T> weightList)
        {
            try
            {
                _logger.LogInformation("Repository: SaveWeights - Start");

                _context.Set<T>().AddRange(weightList);
                _context.SaveChanges();

                _logger.LogInformation("Repository: SaveWeights - Finish - Weights saved");

                return weightList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Repository: SaveWeights - Error: ", ex.Message);
                throw ex;
            }
        }
    }
}
