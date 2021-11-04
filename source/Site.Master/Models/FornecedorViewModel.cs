using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Site.Master.Models
{
    public class FornecedorViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} deve ter no maximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "Se o campo {0} for cnpj deve ter {1} caracteres se não {2} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public DateTime DataCriacao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(13, ErrorMessage = "O campo {0} deve ser informado com ou sem DDD", MinimumLength = 9)]
        public string Telefone { get; set; }

        [Display(Name = "Contato")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} deve ser informado com no maximo {1} caracteres")]
        public string Email { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
