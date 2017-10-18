using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }

        [Required(ErrorMessage ="Informe o cargo")]
        [Display(Name ="Descrição do cargo")]
        [StringLength(40, ErrorMessage ="O cargo é composto por no máximo 40 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
