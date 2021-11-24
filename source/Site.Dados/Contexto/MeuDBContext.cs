using Microsoft.EntityFrameworkCore;
//using Site.Negocios.Entidades;
using System.Linq;

namespace Site.Dados.Contexto
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<Site.Negocios.Entidades.Produto> Produtos { get; set; }
        public DbSet<Site.Negocios.Entidades.Fornecedor> Fornecedores { get; set; }
        public DbSet<Site.Negocios.Entidades.Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
