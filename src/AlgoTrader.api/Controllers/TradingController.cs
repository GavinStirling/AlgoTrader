using AlgoTrader.api.TradingTools;
using Microsoft.AspNetCore.Mvc;

namespace AlgoTrader.api.Controllers
{
    [ApiController]
    [Route("/trading")]
    public class TradingController : ControllerBase
    {
        private readonly Trader _trader;

        public TradingController(Trader trader)
        {
            _trader = trader;
        }

        public async Task<IActionResult> RunBot([FromQuery] string symbol)
        {
            try
            {
                var result = _trader.RunAsync(symbol);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
