using Microsoft.Extensions.Logging;
using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Objects.DTOs;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public EmployeeRegisterDTO SaveEmployeesService(List<Employee> employees)
        {
            _logger.LogInformation("Service: GetEmployeesService - Start - Employees received: " + employees.Count());

            EmployeeRegisterDTO employeeRegisterDTO = new EmployeeRegisterDTO();

            foreach (Employee employee in employees)
            {
                bool isValidEmployee = employee.IsValidEmployee();

                if (isValidEmployee)
                {
                    _logger.LogInformation("Service: GetEmployeesService - Employee: " + employee.ToString() + " is valid.");

                    employeeRegisterDTO.EmployeesRegistered.Add(employee);
                }
                else
                {
                    _logger.LogInformation("Service: GetEmployeesService - Employee: " + employee.ToString() + " not is valid.");

                    employeeRegisterDTO.EmployeesNotRegistered.Add(employee);
                }
            }


            _employeeRepository.SaveEmployees(employeeRegisterDTO.EmployeesRegistered);

            _logger.LogInformation("Service: GetEmployeesService - Employees saved: " + employeeRegisterDTO.EmployeesRegistered.Count());
            _logger.LogInformation("Service: GetEmployeesService - Employees not saved: " + employeeRegisterDTO.EmployeesNotRegistered.Count());

            _logger.LogInformation("Service: GetEmployeesService - Finish ");
            return employeeRegisterDTO;
        }
    }
}
