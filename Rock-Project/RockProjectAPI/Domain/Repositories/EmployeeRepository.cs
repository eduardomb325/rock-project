using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Context;
using RockProjectAPI.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly ApiContext _context;

        public EmployeeRepository(ApiContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                _logger.LogInformation("Repository: GetEmployees - Start");

                List<Employee> employeeList = _context.Employees.ToList();

                _logger.LogInformation("Repository: GetEmployees - Finish - Employees founded: " + employeeList.Count().ToString());

                return employeeList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Repository: GetEmployees - Error: "+ ex.Message);
                throw ex;
            }
        }

        public List<Employee> SaveEmployees(List<Employee> employees)
        {
            try
            {
                _logger.LogInformation("Repository: SaveEmployees - Start");

                _context.Employees.AddRange(employees);
                _context.SaveChanges();

                _logger.LogInformation("Repository: SaveEmployees - Finish - Employees saved");

                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError("Repository: SaveEmployees - Error: "+ ex.Message);
                throw ex;
            }
        }
    }
}
