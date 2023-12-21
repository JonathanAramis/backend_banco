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
        public async Task<IEnumerable<ExtratoContaCorrente>> ObterExtrato()
        {
            return await _extratoContaCorrenteDbContext.ExtratoContaCorrentes.ToListAsync();            
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
    }
}
