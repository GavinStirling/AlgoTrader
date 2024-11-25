using AlgoTrader.api.Models;
using AlgoTrader.api.Services;

namespace AlgoTrader.api.TradingTools
{
    public interface ITradingStrategy
    {
        TradeOrder ExecuteStrategy(MarketData marketData);
    }
}
