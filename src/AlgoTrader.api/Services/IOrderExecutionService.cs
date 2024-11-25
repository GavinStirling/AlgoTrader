using AlgoTrader.api.Models;

namespace AlgoTrader.api.Services
{
    public interface IOrderExecutionService
    {
        Task<bool> PlaceOrderAsync(TradeOrder tradeOrder);
    }
}
