namespace OrderAccumulator.Domain.Response
{
    public class OrderResponse
    {
        public bool Sucesso { get; set; }
        public decimal? Exposicao_Atual { get; set; }
        public string Msg_Erro { get; set; }
    }
}
