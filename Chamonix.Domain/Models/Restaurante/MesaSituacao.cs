using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Restaurante
{
    public class MesaSituacao
    {
        [Key]
        public int MesaSituacaoId { get; set; }

        [Display(Name = "Situação da mesa")]
        [Required(ErrorMessage = "Informe a situação da mesa")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
