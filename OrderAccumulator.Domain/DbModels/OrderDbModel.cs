namespace OrderAccumulator.Domain.DbModels
{
    public class OrderDbModel
    {
        public int Id { get; set; }
        public string Asset { get; set; }
        public string Side { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
    }
}
