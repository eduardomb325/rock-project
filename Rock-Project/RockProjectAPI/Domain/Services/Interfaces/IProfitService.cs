using RockProjectAPI.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IProfitService
    {
        Profit GetProfit(double expectedProfit);
    }
}
