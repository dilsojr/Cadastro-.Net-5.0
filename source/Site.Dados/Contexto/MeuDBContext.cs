using Microsoft.EntityFrameworkCore;
using Site.Negocios.Entidades;
using System.Linq;

namespace Site.Dados.Contexto
{
    public class MeuDBContext : DbContext
    {
        public MeuDBContext (DbContextOptions<MeuDBContext> dbContextOptions) : base (dbContextOptions)
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDBContext).Assembly);

            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
