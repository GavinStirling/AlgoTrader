using AlgoTrader.api.Services;
using AlgoTrader.api.TradingTools;
using Microsoft.AspNetCore.Mvc;

namespace AlgoTrader.api.Controllers
{
    [ApiController]
    [Route("/trading")]
    public class TradingController : ControllerBase
    {
        /*
         * TODO
         * 
         * - Change the controller to be able to manage a trading service which can create multiple trader instances (multiple threads)
         * 
         * 
         */
        
        private readonly Trader _trader;

        public TradingController(Trader trader)
        {
            _trader = trader;
        }

        public async Task<IActionResult> RunBot([FromQuery] string symbol)
        {
            try
            {
                // Create new cancellation token
                var cts = new CancellationTokenSource();

                // Create a new market data stream and connect to the requested symbol
                IMarketDataStreamService marketDataStream = new MarketDataStreamService();
                await marketDataStream.ConnectAsync($"example-uri.com/{symbol}", cts.Token);
          
                _trader.SubscribeToMarketData(marketDataStream);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
