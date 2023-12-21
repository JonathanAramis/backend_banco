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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=Jonathan;Initial Catalog=banco_task;Data Source=localhost\\SQLEXPRESS; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
