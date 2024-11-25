using AlgoTrader.api.Models.Enums;

namespace AlgoTrader.api.Models
{
    public class TradeOrder
    {
        public Guid Id { get; set; } = new Guid();
        public Asset Asset { get; set; } = new();
        public double Quantity { get; set; }
        public double Price { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime Created { get; set; }
    }
}
