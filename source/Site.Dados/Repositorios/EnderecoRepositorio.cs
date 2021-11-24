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
    public class EnderecoRepositorio : Repositorio<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(MeuDbContext meuDbContext) : base(meuDbContext)
        { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await contexto.Enderecos.Where(x => x.FornecedorId == fornecedorId).FirstOrDefaultAsync();
        }
    }
}
