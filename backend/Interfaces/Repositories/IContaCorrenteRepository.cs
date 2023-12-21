using backend.Models.Responses;

namespace backend.Interfaces.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<bool> IncluirExtrato(ExtratoContaCorrenteRequest request);
    }
}
