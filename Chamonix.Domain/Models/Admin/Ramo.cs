using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Ramo
    {
        [Key]
        public int RamoId { get; set; }

        [Required(ErrorMessage = "Informe o ramo")]
        [Display(Name = "Ramo de fornecimento")]
        [StringLength(60, ErrorMessage = "O Ramo de fornecimento é composto por no máximo 60 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Alterado Em")]
        public DateTime AlteradoEm { get; set; }

        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }
    }
}
