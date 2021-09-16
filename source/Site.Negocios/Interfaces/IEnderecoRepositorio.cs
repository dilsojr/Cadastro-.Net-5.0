using Site.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace Site.Negocios.Interfaces
{
    public interface IEnderecoRepositorio : IRepositorio<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
