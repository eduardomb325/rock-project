using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Repositories.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OccupationAreaWeight>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<SalaryWeight>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Entity<SalaryWeight>()
                .Property(x => x.OccupationPositionException)
                .HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => JsonConvert.DeserializeObject<List<string>>(x)
                );

            builder.Entity<WorkYearsWeight>().Property(x => x.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<OccupationAreaWeight> OccupationAreaWeights { get; set; }

        public DbSet<SalaryWeight> SalaryWeights { get; set; }

        public DbSet<WorkYearsWeight> WorkYearsWeights { get; set; }
    }
}
