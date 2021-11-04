using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Site.Master.Models
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} aceita entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
       
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} aceita entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public decimal Valor { get; set; }
        public DateTime DataInclusao { get; set; }

        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(1000, ErrorMessage = "O estoque deve ter no minimo um de quantidade", MinimumLength = 1)]
        public int QuantidadeEstoque { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
    }
}
