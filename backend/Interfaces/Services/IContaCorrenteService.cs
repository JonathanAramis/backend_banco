using backend.Models.Responses;

namespace backend.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        Task IncluirExtrato(ExtratoContaCorrenteRequest request);
        Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato();
    }
}
