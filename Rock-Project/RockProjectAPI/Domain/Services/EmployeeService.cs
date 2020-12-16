using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private ILogger<EmployeeService> _logger;
        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        
        public List<Employee> GetEmployeesService()
        {
            _logger.LogInformation("Service: GetEmployeesService - Start");

            List<Employee> employeesList = _employeeRepository.GetEmployees();

            _logger.LogInformation("Service: GetEmployeesService - Finish");

            return employeesList;
        }

        public List<Employee> SaveEmployeesService(List<Employee> employees)
        {
            _logger.LogInformation("Service: GetEmployeesService - Start - Employees received: ", employees.Count());

            List<Employee> employeesList = _employeeRepository.SaveEmployees(employees);

            _logger.LogInformation("Service: GetEmployeesService - Finish - Employees saved: ", employeesList.Count());

            return employeesList;
        }
    }
}
