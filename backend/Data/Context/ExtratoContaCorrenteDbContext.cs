using backend.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Context
{
    public class ExtratoContaCorrenteDbContext : DbContext
    {
        public ExtratoContaCorrenteDbContext(DbContextOptions<ExtratoContaCorrenteDbContext> options) : base(options) { }
        public DbSet<ExtratoContaCorrente> ExtratoContaCorrentes { get; set; }
        public DbSet<ExtratoStatus> ExtratoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
