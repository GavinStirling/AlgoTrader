using AlgoTrader.api.Models;
using AlgoTrader.api.Models.Enums;

namespace AlgoTrader.api.TradingTools
{
    public class SimpleMovingAverage : ITradingStrategy
    {

        /* TODO:
         * Develop better logic for entering and exiting positions
         * Analyse more than the immediate price (moving averages etc)
         * Develop quant strategies implementation
        */

        public TradeOrder ExecuteStrategy(MarketData marketData)
        {
            // Example trade execution logic for now
            if (marketData.Asset.CurrentPrice < 100)
            {
                return new TradeOrder
                {
                    Asset = marketData.Asset,
                    Quantity = 10,
                    Price = marketData.Asset.CurrentPrice,
                    OrderType = OrderType.Buy,
                    Created = DateTime.Now,
                };
            }

            return null;
        }
    }
}
