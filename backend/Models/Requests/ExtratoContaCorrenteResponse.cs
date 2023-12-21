namespace backend.Models.Responses
{
    public class ExtratoContaCorrenteRequest
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double Valor { get; set; }
        public bool Avulso { get; set; }
        public int Status { get; set; }
    }
}
