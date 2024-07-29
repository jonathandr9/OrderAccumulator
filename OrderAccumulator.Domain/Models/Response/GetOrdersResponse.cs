namespace OrderAccumulator.Domain.Models.Response
{
    public class GetOrdersResponse
    {
        public bool sucesso { get; set; }
        public string msg_erro { get; set; }
        public IEnumerable<GetOrdersReponseItem> ordens { get; set; }
    }

    public class GetOrdersReponseItem
    {
        public string ativo { get; set; }
        public char lado { get; set; }
        public int quantidade { get; set; }
        public decimal preco { get; set; }
        public string data { get; set; }
    }
}
