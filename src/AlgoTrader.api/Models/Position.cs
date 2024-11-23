namespace AlgoTrader.api.Models
{
    public class Position
    {
        public Guid Id { get; set; } = new Guid();
        public Asset Asset { get; set; } = new();
        public double OriginalPrice { get; set; }
        public double Quantity { get; set; }
        public DateTime Created { get; set; }
    }
}
