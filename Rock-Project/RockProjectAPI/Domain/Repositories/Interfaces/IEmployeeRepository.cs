using RockProjectAPI.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees ();

        List<Employee> SaveEmployees (List<Employee> employees);
    }
}
