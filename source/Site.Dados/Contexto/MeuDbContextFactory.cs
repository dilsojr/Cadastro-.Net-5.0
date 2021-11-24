using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Site.Dados.Contexto
{
    //https://docs.microsoft.com/pt-br/ef/core/cli/dbcontext-creation?tabs=vs
    public class MeuDbContextFactory : IDesignTimeDbContextFactory<MeuDbContext>
    {
        public MeuDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeuDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProjetoCadastro;uid=sa;pwd=sa;MultipleActiveResultSets=true");

            return new MeuDbContext(optionsBuilder.Options);
        }
    }
}
