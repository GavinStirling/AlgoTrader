namespace AlgoTrader.api.Models
{
    public class MarketData
    {
        public Asset Asset { get; set; } = new();
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
