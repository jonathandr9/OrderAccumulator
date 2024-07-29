namespace OrderAccumulator.Domain.Models
{
    public class FinancialExposureModel
    {
        public decimal ExposureValue { get; set; }
        public bool Success { get; set; }

        public void ExposureValueCalc(IEnumerable<OrderModel> allOrders)
        {
            var totalPurchases = allOrders
                   .Where(x => x.Side == 'C')
                   .Sum(x => x.Price * x.Quantity);

            var totalSales = allOrders
                .Where(x => x.Side == 'V')
                .Sum(x => x.Price * x.Quantity);

            this.ExposureValue = totalPurchases - totalSales;
        }

        public bool ExposureValueCheck()
        {
            this.Success = this.ExposureValue < 1000000;
            return Success;
        }
    }

}
