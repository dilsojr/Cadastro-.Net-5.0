using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Site.Negocios.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<List<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<List<Produto>> ObterProdutosEFornecdores();

    }
}
