using Microsoft.EntityFrameworkCore;
using Site.Dados.Contexto;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Dados.Repositorios
{
    public class FornecedorRepositorio : Repositorio<Fornecedor>, IFornecedorRepositorio
    {
        public FornecedorRepositorio(MeuDbContext meuDbContext): base(meuDbContext)
        { }

        public  async Task<Fornecedor> ObterFornecedorEEndereco(Guid id)
        {
            return await contexto.Fornecedores.Where(x => x.Id == id).Include(x => x.Endereco).FirstOrDefaultAsync();
        }

        public async Task<Fornecedor> ObterFornecedorEnderecoEProduto(Guid id)
        {
            return await contexto.Fornecedores.Where(x => x.Id == id).Include(x => x.Endereco).Include(x => x.Produtos).FirstOrDefaultAsync();
        }
    }
}
