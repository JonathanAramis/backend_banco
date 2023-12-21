using backend.Models.Responses;

namespace backend.Interfaces.Repositories
{
    public interface IContaCorrenteRepository
    {
        void AtualizarExtrato(AtualizarExtratoContaCorrenteResponse request);
        void IncluirExtrato(ExtratoContaCorrenteRequest request);
        Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato(ObterExtratoContaCorrenteRequest request);
    }
}
