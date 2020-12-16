using RockProjectAPI.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeesService();
        List<Employee> SaveEmployeesService(List<Employee> employees);
    }
}
