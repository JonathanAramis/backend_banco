using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models.Responses;

namespace backend.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public void AtualizarExtrato(AtualizarExtratoContaCorrenteResponse request)
        {
            if (request.Id == 0) throw new Exception($"{nameof(request.Id)} não pode ser nulo");
            else if (request.Valor == 0) throw new Exception($"{nameof(request.Valor)} não pode ser nulo");

            _contaCorrenteRepository.AtualizarExtrato(request);
        }

        public async Task IncluirExtrato(ExtratoContaCorrenteRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _contaCorrenteRepository.IncluirExtrato(request);
        }

        public async Task<ObterExtratoContaCorrenteResponse> ObterExtrato(ObterExtratoContaCorrenteRequest request)
        {
            var result = await _contaCorrenteRepository.ObterExtrato(request);
            var somaValor = result.Sum(a => a.Valor);
            return new ObterExtratoContaCorrenteResponse()
            {
                Extrato = result,
                ValorTotal = (decimal)somaValor
            };
        }
    }
}
