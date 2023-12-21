namespace backend.Models.Responses
{
    public class ObterExtratoContaCorrenteResponse
    {
        public IEnumerable<ExtratoContaCorrente> Extrato { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
