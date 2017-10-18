using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class ContaCategoria
    {
        [Key]
        public int ContaCategoriaId { get; set; }

        [Display(Name = "Categoria")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Alterado em")]
        [DataType(DataType.Date)]
        public DateTime AlteradoEm { get; set; }

        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}