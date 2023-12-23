using Azure.Core;
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

        public async Task<ExtratoContaCorrente> ObterExtratoPorId(int extratoId)
        {
            var result = await _extratoContaCorrenteDbContext.ExtratoContaCorrentes.AsNoTracking().FirstOrDefaultAsync(a => a.Id == extratoId);
            if (result == null) return new ExtratoContaCorrente() { };
            return result;
        }

        public void IncluirExtrato(ExtratoContaCorrente request)
        {
            _extratoContaCorrenteDbContext.ExtratoContaCorrentes.Add(request);
            _extratoContaCorrenteDbContext.SaveChanges();
        }

        public void AtualizarExtrato(AtualizarExtratoContaCorrenteRequest request)
        {
            var extratoContaCorrente = new ExtratoContaCorrente()
            {
                Id = request.Id,
                Valor = request.Valor,
                Data = DateTime.Now,
            };

            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.Valor).IsModified = true;
            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.Data).IsModified = true;
            _extratoContaCorrenteDbContext.SaveChanges();
        }

        public void CancelarExtrato(int extratoId)
        {
            var extratoContaCorrente = new ExtratoContaCorrente()
            {
                Id = extratoId,
                StatusId = (int)EExtratoStatus.Cancelado,
                Data = DateTime.Now,
            };

            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.StatusId).IsModified = true;
            _extratoContaCorrenteDbContext.Entry(extratoContaCorrente).Property(e => e.Data).IsModified = true;
            _extratoContaCorrenteDbContext.SaveChanges();
        }
    }
}
