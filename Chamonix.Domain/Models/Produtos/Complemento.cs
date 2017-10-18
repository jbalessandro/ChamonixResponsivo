using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Produtos
{
    public class Complemento
    {
        [Key]
        public int ComplementoId { get; set; }

        [Display(Name = "Complemento do produto")]
        [Required(ErrorMessage = "Informe o complemento")]
        [StringLength(40, ErrorMessage = "Máximo 60 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
