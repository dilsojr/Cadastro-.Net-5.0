using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Site.Master.Models
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} aceita entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Rua { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} aceita entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Bairro { get; set; }
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ter {1} caracteres", MinimumLength = 8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} deve ter {1} caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(2, ErrorMessage = "O campo {0} deve ter {1} caracteres, deve ser informado a sigla do estado", MinimumLength = 2)]
        public string Estado { get; set; }
        
        [HiddenInput]
        public Guid FornecedorId { get; set; }
    }
}
