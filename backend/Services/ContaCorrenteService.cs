using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models.Responses;

namespace backend.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository) {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task IncluirExtrato(ExtratoContaCorrenteRequest request)
        {
            _contaCorrenteRepository.IncluirExtrato(request);
        }

        public async Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato()
        {
            return await _contaCorrenteRepository.ObterExtrato();
        }
    }
}
