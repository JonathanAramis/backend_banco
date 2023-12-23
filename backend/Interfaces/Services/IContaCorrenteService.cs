using backend.Models.Responses;

namespace backend.Interfaces.Services
{
    public interface IContaCorrenteService
    {
        void AtualizarExtrato(AtualizarExtratoContaCorrenteRequest request);
        Task CancelarExtrato(int extratoId);
        Task IncluirExtratoAvulso(ExtratoContaCorrenteRequest request);
        Task<ObterExtratoContaCorrenteResponse> ObterExtrato(ObterExtratoContaCorrenteRequest request);
        Task IncluirExtratoNaoAvulso(ExtratoContaCorrenteRequest request);
    }
}
