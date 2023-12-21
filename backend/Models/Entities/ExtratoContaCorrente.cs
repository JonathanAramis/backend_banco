namespace backend.Models.Responses
{
    public class ExtratoContaCorrente
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public bool Avulso { get; set; }
        public ExtratoStatus Status { get; set; }
    }
}
