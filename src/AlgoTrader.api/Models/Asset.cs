namespace AlgoTrader.api.Models
{
    public class Asset
    {
        public string Name { get; set; } = "";
        public string Ticker { get; set; } = "";
        public double CurrentPrice { get; set; }
    }
}
