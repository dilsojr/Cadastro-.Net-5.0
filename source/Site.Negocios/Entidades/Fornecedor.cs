using System;
using System.Collections.Generic;

namespace Site.Negocios.Entidades
{
    public class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
