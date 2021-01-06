using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace RockProjectAPI.Domain.Services
{
    public class WeightService<T> : IWeightService<T> where T : class
    {
        private readonly IDataStarterGenerator _dataStarterGenerator;
        private ILogger<WeightService<T>> _logger;
        private readonly IWeightRepository<T> _weightRepository;

        public WeightService(IDataStarterGenerator dataStarterGenerator, ILogger<WeightService<T>> logger, IWeightRepository<T> weightRepository)
        {
            _dataStarterGenerator = dataStarterGenerator;
            _logger = logger;
            _weightRepository = weightRepository;
        }
        public List<T> SaveWeightList(List<T> weightList)
        {
            _logger.LogInformation("Service: WeightService - Method: AddWeight - Start - Weights to Save: " + weightList);

            List<T> response = _weightRepository.SaveWeightList(weightList);

            _logger.LogInformation("Service: WeightService - Method: AddWeight - Finish - Saved weights: " + response.ToString());

            return response;
        }

        public List<T> GetWeightList()
        {
            _logger.LogInformation("Service: WeightService - Method: GetWeightList - Start");

            int count = _weightRepository.CountWeightList();

            if (count <= 0)
            {
                _dataStarterGenerator.InitializeWeightDb();
            }

            List<T> response = _weightRepository.GetWeightList();

            _logger.LogInformation("Service: WeightService - Method: GetWeightList - Finish - Items founded: " + response.ToString());

            return response;
        }
    }
}
