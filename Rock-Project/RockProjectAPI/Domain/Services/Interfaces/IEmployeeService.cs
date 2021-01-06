using RockProjectAPI.Domain.Objects;
using RockProjectAPI.Domain.Objects.DTOs;
using System.Collections.Generic;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeesService();
        EmployeeRegisterDTO SaveEmployeesService(List<Employee> employees);
    }
}
