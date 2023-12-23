using Azure.Core;
using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models.Responses;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public void AtualizarExtrato(AtualizarExtratoContaCorrenteRequest request)
        {
            if (request.Id == 0) throw new Exception($"{nameof(request.Id)} não pode ser nulo");
            else if (request.Valor == 0) throw new Exception($"{nameof(request.Valor)} não pode ser nulo");

            _contaCorrenteRepository.AtualizarExtrato(request);
        }

        public async Task CancelarExtrato(int extratoId)
        {
            var result = await _contaCorrenteRepository.ObterExtratoPorId(extratoId);
            if (result.StatusId == (int)EExtratoStatus.Valido && result.Avulso)            
                _contaCorrenteRepository.CancelarExtrato(extratoId);
            else
                throw new Exception($"Não foi possível cancelar o extrato");
        }

        public async Task IncluirExtratoNaoAvulso(ExtratoContaCorrenteRequest request)
        {
            if (request.Valor == 0) throw new Exception($"{nameof(request.Valor)} não pode ser nulo");
            if (request.Descricao.IsNullOrEmpty()) throw new Exception($"{nameof(request.Descricao)} não pode ser nulo");

            var requestDb = new ExtratoContaCorrente()
            {
                Descricao = request.Descricao,
                Avulso = false,
                Data = DateTime.Now,
                StatusId = (int)EExtratoStatus.Valido,
                Valor = request.Valor,
            };

            _contaCorrenteRepository.IncluirExtrato(requestDb);
        }

        public async Task IncluirExtratoAvulso(ExtratoContaCorrenteRequest request)
        {
            if (request.Valor == 0) throw new Exception($"{nameof(request.Valor)} não pode ser nulo");
            if (request.Descricao.IsNullOrEmpty()) throw new Exception($"{nameof(request.Descricao)} não pode ser nulo");

            var requestDb = new ExtratoContaCorrente()
            {
                Descricao = request.Descricao,
                Avulso = true,
                Data = DateTime.Now,
                StatusId = (int)EExtratoStatus.Valido,
                Valor = request.Valor,
            };

            _contaCorrenteRepository.IncluirExtrato(requestDb);
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
