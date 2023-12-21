using backend.Data.Context;
using backend.Interfaces.Repositories;
using backend.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ExtratoContaCorrenteDbContext _extratoContaCorrenteDbContext;
        public ContaCorrenteRepository(ExtratoContaCorrenteDbContext extratoContaCorrenteDbContext)
        {
            _extratoContaCorrenteDbContext = extratoContaCorrenteDbContext;
        }
        public async Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato(ObterExtratoContaCorrenteRequest request)
        {
            return _extratoContaCorrenteDbContext.ExtratoContaCorrentes.Where(a => (a.Data >= request.DataInicio) && (a.Data <= request.DataFim));
        }

        public void IncluirExtrato(ExtratoContaCorrenteRequest request)
        {
            var requestDb = new ExtratoContaCorrente()
            {
                Descricao = request.Descricao,
                Avulso = request.Avulso,
                Data = DateTime.Now,
                StatusId = request.Status,
                Valor = request.Valor,
            };

            _extratoContaCorrenteDbContext.ExtratoContaCorrentes.Add(requestDb);
            _extratoContaCorrenteDbContext.SaveChanges();
        }

        public void AtualizarExtrato(AtualizarExtratoContaCorrenteResponse request)
        {
            var extratoContaCorrente = new ExtratoContaCorrente()
            {
                Id = request.Id,
                Valor = request.Valor,
                Data = DateTime.Now,
            };

            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.Valor).IsModified = true;
            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.Data).IsModified = true;
            //_extratoContaCorrenteDbContext.ExtratoContaCorrentes.Update(extratoContaCorrente);
            _extratoContaCorrenteDbContext.SaveChanges();
        }
    }
}
