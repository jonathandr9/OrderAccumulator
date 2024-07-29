namespace OrderAccumulator.Domain.Response
{
    public class OrderResponse
    {
        public bool sucesso { get; set; }
        public decimal? exposicao_atual { get; set; }
        public string msg_erro { get; set; }
    }
}
