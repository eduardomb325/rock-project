using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services
{
    public class WeightService<T> : IWeightService<T> where T : class
    {
        private ILogger<WeightService<T>> _logger;
        private readonly IWeightRepository<T> _weightRepository;

        public WeightService(ILogger<WeightService<T>> logger, IWeightRepository<T> weightRepository)
        {
            _logger = logger;
            _weightRepository = weightRepository;
        }
        public List<T> SaveWeightList(List<T> weightList)
        {
            _logger.LogInformation("Service: WeightService - Method: AddWeight - Start - Weights to Save: " + weightList.ToString());

            List<T> response = _weightRepository.SaveWeightList(weightList);

            _logger.LogInformation("Service: WeightService - Method: AddWeight - Finish - Saved weights: " + response.ToString());

            return response; 
        }

        public List<T> GetWeightList()
        {
            _logger.LogInformation("Service: WeightService - Method: GetWeightList - Start");

            List<T> response = _weightRepository.GetWeightList();

            _logger.LogInformation("Service: WeightService - Method: GetWeightList - Finish - Items founded: " + response.Count());

            return response;
        }
    }
}
