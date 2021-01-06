using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories;
using RockProjectAPI.Domain.Repositories.Context;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services;
using RockProjectAPI.Domain.Services.Interfaces;

namespace RockProjectAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Using In-Memory DB
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("RockProject"));

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped(typeof(IWeightRepository<>), typeof(WeightRepository<>));

            //Services
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IProfitService, ProfitService>();

            services.AddScoped(typeof(IWeightService<>), typeof(WeightService<>));

            services.AddScoped<IDataStarterGenerator, DataStarterGenerator>();

            //Adding Swagger
            services.AddSwaggerGen(config =>
                {
                    config.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = Configuration["ApplicationName"],
                            Version = Configuration["ApplicationVersion"],
                            Description = Configuration["ApplicationName"]
                        }
                    );
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            //Use Swagger JSON (like swagger, version, swagger.json)
            app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint(Configuration["SwaggerUrl"], Configuration["ApplicationName"]);
                }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
