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
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(MeuDBContext meuDBContext) : base(meuDBContext)
        {
        }

        public virtual async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(x => x.FornecedorId == fornecedorId);
        }
        
        public async Task<IEnumerable<Produto>> ObterProdutosEFornecedores()
        {
            return await contexto.Produtos.AsNoTracking().Include(x => x.Fornecedor).OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
