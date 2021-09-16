using Site.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace Site.Negocios.Interfaces
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorEnderecoEProduto(Guid id);
    }
}
