using RockProjectAPI.Domain.Objects;

namespace RockProjectAPI.Domain.Services.Interfaces
{
    public interface IProfitService
    {
        Profit GetProfit(double expectedProfit);
    }
}
