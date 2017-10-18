using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }

        [Required(ErrorMessage ="Informe a UF")]
        [Display(Name ="UF")]
        [StringLength(2, ErrorMessage ="UF inválida", MinimumLength = 2)]
        public string UF { get; set; }

        public bool Ativo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Alterado Em")]
        public DateTime AlteradoEm { get; set; }

        [Display(Name ="Usuario")]
        public int UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
    }
}
