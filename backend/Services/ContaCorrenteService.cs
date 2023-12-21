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
            await _contaCorrenteRepository.IncluirExtrato(request);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtratoContaCorrenteResponse>> ObterExtrato()
        {
            var extratoContaCorrente = new ExtratoContaCorrenteResponse()
            {
                Id = 1,
                Status = "Válido",
                Avulso = true,
                Data = DateTime.Now,
                Descricao = "teste mock",
                Valor = 123.4
            };
            var response = new List<ExtratoContaCorrenteResponse>() { extratoContaCorrente };
            return response;
        }
    }
}
