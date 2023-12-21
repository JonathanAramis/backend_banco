using backend.Models.Responses;

namespace backend.Interfaces.Repositories
{
    public interface IContaCorrenteRepository
    {
        void IncluirExtrato(ExtratoContaCorrenteRequest request);
        Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato();
    }
}
