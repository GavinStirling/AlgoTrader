using AlgoTrader.api.Models;
using AlgoTrader.api.TradingTools;

namespace AlgoTrader.api.Services
{
    public interface ITradingService
    {
        Task<List<Trader>> GetTradersAsync();
        Task<Trader> StartTraderAsync(Asset asset, ITradingStrategy tradingStrategy);
        Task<Trader> StopTraderAsync(Trader trader);
    }
}
