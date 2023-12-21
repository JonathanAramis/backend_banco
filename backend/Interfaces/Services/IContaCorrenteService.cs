using backend.Models.Responses;

namespace backend.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        void AtualizarExtrato(AtualizarExtratoContaCorrenteResponse request);
        Task IncluirExtrato(ExtratoContaCorrenteRequest request);
        Task<ObterExtratoContaCorrenteResponse> ObterExtrato(ObterExtratoContaCorrenteRequest request);
    }
}
