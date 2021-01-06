using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects.DTOs
{
    public class EmployeeRegisterDTO
    {
        public List<Employee> EmployeesRegistered { get; set; } = new List<Employee>();
        public List<Employee> EmployeesNotRegistered { get; set; } = new List<Employee>();

        public EmployeeRegisterDTO()
        {
        }
    }
}
