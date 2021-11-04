using AutoMapper;
using Site.Master.Models;
using Site.Negocios.Entidades;

namespace Site.Master.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
