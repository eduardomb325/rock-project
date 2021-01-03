using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Objects.Interfaces
{
    public interface IEmployeeBase
    {
        string Matricula { get; set; }
        string Nome { get; set; }
    }
}
