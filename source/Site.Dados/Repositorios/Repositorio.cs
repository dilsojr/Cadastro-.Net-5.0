using Microsoft.EntityFrameworkCore;
using Site.Dados.Contexto;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Site.Dados.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade, new ()
    {
        public readonly MeuDBContext contexto;
        protected readonly DbSet<T> DbSet;

        public Repositorio(MeuDBContext meuDBContext)
        {
            contexto = meuDBContext;
            DbSet = meuDBContext.Set<T>();
        }

        public async Task Adicionar(T entidade)
        {
            DbSet.Add(entidade);
            await Salvar();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> expressao)
        {
            return await DbSet.AsNoTracking().Where(expressao).ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task Atualizar(T entidade)
        {
            DbSet.Update(entidade);
            await Salvar();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await Salvar();
        }

        public async Task<int> Salvar()
        {
            return await contexto.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            contexto?.Dispose();
        }
    }
}
