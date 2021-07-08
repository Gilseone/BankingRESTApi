using Microsoft.EntityFrameworkCore;

namespace BankingRESTApi.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasOne(x => x.Conta).WithOne(x => x.Cliente).HasForeignKey<Cliente>(x => x.ContaId);

            modelBuilder.Entity<Conta>().HasOne(x => x.Cliente).WithOne(x => x.Conta);
        }
    }
}