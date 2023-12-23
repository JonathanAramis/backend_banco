using backend.Models.Responses;

namespace backend.Interfaces.Repositories
{
    public interface IContaCorrenteRepository
    {
        void AtualizarExtrato(AtualizarExtratoContaCorrenteRequest request);
        void CancelarExtrato(int extratoId);
        void IncluirExtrato(ExtratoContaCorrente request);
        Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato(ObterExtratoContaCorrenteRequest request);
        Task<ExtratoContaCorrente> ObterExtratoPorId(int extratoId);
    }
}
