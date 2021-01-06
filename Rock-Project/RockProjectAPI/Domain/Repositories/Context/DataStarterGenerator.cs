using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace RockProjectAPI.Domain.Repositories.Context
{
    public class DataStarterGenerator : IDataStarterGenerator
    {
        private readonly IWeightRepository<OccupationAreaWeight> _occupationAreaRepository;
        private readonly IWeightRepository<SalaryWeight> _salaryWeightRepository;
        private readonly IWeightRepository<WorkYearsWeight> _workYearsWeightRepository;

        public DataStarterGenerator(
                IWeightRepository<OccupationAreaWeight> occupationAreaRepository,
                IWeightRepository<SalaryWeight> salaryWeightRepository,
                IWeightRepository<WorkYearsWeight> workYearsWeightRepository
            )
        {
            _occupationAreaRepository = occupationAreaRepository;
            _salaryWeightRepository = salaryWeightRepository;
            _workYearsWeightRepository = workYearsWeightRepository;
        }

        public List<OccupationAreaWeight> GenerateStarterOccupationAreaWeightList()
        {
            List<OccupationAreaWeight> occupationAreaWeightList = new List<OccupationAreaWeight>();

            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 1, OccupationArea = "Diretoria", Weight = 1 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 2, OccupationArea = "Contabilidade", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 3, OccupationArea = "Financeiro", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 4, OccupationArea = "Tecnologia", Weight = 2 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 5, OccupationArea = "Serviços Gerais", Weight = 3 });
            occupationAreaWeightList.Add(new OccupationAreaWeight { Id = 6, OccupationArea = "Relacionamento com o Cliente", Weight = 5 });

            return occupationAreaWeightList;
        }

        public List<SalaryWeight> GenerateStarterSalaryWeightList()
        {
            List<SalaryWeight> salaryWeightList = new List<SalaryWeight>();

            salaryWeightList.Add(new SalaryWeight { Id = 1, SalaryMin = 0, SalaryMax = 1, OccupationPositionException = new List<string> {"Estagiário"}, Weight = 1 });
            salaryWeightList.Add(new SalaryWeight { Id = 2, SalaryMin = 1, SalaryMax = 3, Weight = 2 });
            salaryWeightList.Add(new SalaryWeight { Id = 3, SalaryMin = 3, SalaryMax = 5, Weight = 2 });
            salaryWeightList.Add(new SalaryWeight { Id = 4, SalaryMin = 5, SalaryMax = 8, Weight = 3 });
            salaryWeightList.Add(new SalaryWeight { Id = 5, SalaryMin = 8, SalaryMax = 8, Weight = 5 });

            return salaryWeightList;
        }

        public List<WorkYearsWeight> GenerateStarterWorkYearsWeightList()
        {
            List<WorkYearsWeight> workYearWeightList = new List<WorkYearsWeight>();

            workYearWeightList.Add(new WorkYearsWeight { Id = 1, YearMin = 0, YearMax = 1, Weight = 1 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 2, YearMin = 1, YearMax = 3, Weight = 2 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 3, YearMin = 3, YearMax = 8, Weight = 3 });
            workYearWeightList.Add(new WorkYearsWeight { Id = 4, YearMin = 8, YearMax = 8, Weight = 5 });

            return workYearWeightList;
        }

        public void InitializeWeightDb()
        {
            _occupationAreaRepository.SaveWeightList(GenerateStarterOccupationAreaWeightList());
            _salaryWeightRepository.SaveWeightList(GenerateStarterSalaryWeightList());
            _workYearsWeightRepository.SaveWeightList(GenerateStarterWorkYearsWeightList());
        }
    }
}
