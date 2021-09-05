namespace Site.Negocios.Entidades
{
    public class Endereco : Entidade
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
