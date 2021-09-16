using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Site.Negocios.Interfaces
{
    public interface IRepositorio<T> : IDisposable where T : Entidade
    {
        Task Adicionar(T entidade);
        Task<T> ObterPorId(Guid id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entidade);
        Task Remover(Guid id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> expressao);
        Task<int> Salvar();
    }
}
