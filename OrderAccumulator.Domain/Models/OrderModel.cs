namespace OrderAccumulator.Domain.Models
{
    public class OrderModel
    {
        public string Asset { get; set; }
        public char Side { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
