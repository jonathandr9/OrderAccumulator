namespace OrderAccumulator.API.ViewModels
{
    public class OrderResult
    {
        public bool Sucesso { get; set; }
        public decimal? Exposicao_Atual { get; set; }
        public string Msg_Erro { get; set; }
    }
}
