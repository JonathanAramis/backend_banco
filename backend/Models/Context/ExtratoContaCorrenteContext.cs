using Microsoft.EntityFrameworkCore;

namespace backend.Models.Responses
{
    public class ExtratoContaCorrenteContext : DbContext
    {
        public DbSet<ExtratoContaCorrente> ExtratoContaCorrentes { get; set; }
        public DbSet<ExtratoStatus> ExtratoStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=Jonathan;Initial Catalog=banco_task;Data Source=localhost\\SQLEXPRESS; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
