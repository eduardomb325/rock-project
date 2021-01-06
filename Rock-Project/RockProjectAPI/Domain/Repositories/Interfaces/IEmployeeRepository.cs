using RockProjectAPI.Domain.Objects;
using System.Collections.Generic;

namespace RockProjectAPI.Domain.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        List<Employee> SaveEmployees(List<Employee> employees);
    }
}
