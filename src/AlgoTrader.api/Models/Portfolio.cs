namespace AlgoTrader.api.Models
{
    public class Portfolio
    {
        public double InitialValue { get; } = 0.0;
        public double BuyingPower { get; set; } = 0.0;
        public List<Position> Positions { get; set; } = new();

    }
}
