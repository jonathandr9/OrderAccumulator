namespace OrderAccumulator.API.ViewModels
{
    public class OrderRequest
    {
        public string Ativo { get; set; }
        public char Lado { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
