using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Site.Negocios.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosEFornecedores();

    }
}
