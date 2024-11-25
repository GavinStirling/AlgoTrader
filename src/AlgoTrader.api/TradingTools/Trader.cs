using AlgoTrader.api.Models;
using AlgoTrader.api.Services;
using Newtonsoft.Json;

namespace AlgoTrader.api.TradingTools
{
    public class Trader
    {
        /*
         * TODO:
         * 
         * - Change the setup of the stategy so that it consumes historical data as well
         * - 
         * 
         * 
         */

        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        private readonly ITradingStrategy _tradingStrategy;
        private readonly IOrderExecutionService _orderExecutionService;

        public Trader (ITradingStrategy tradingStrategy, IOrderExecutionService orderExecutionService)
        {
            Id = new Guid();
            Created = DateTime.Now;

            _tradingStrategy = tradingStrategy;
            _orderExecutionService = orderExecutionService;
        }

        public void SubscribeToMarketData(IMarketDataStreamService marketDataStreamService)
        {
            marketDataStreamService.OnMarketDataReceived += async (data) =>
            {
                // Parse the received market data
                var marketData = JsonConvert.DeserializeObject<MarketData>(data);

                // Execute the trading strategy
                var tradeOrder = _tradingStrategy.ExecuteStrategy(marketData);

                if (tradeOrder != null)
                {
                    // Place the order if a trade signal is generated
                    bool tradeSuccess = await _orderExecutionService.PlaceOrderAsync(tradeOrder);
                    Console.WriteLine(tradeSuccess ? "Order placed successfully" : "Failed to place order");
                } else
                {
                    Console.WriteLine("No trade signal generated for the received market data");
                }
            };
        }
    }
}
