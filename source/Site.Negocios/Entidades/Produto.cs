using System;

namespace Site.Negocios.Entidades
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }        
        public Fornecedor Fornecedor { get; set; }
    }
}
