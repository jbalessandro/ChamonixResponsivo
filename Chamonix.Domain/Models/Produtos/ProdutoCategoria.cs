using Chamonix.Domain.Models.Admin;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Produtos
{
    public class ProdutoCategoria
    {
        [Key]
        public int ProdutoCategoriaId { get; set; }

        [Display(Name = "Categoria do produto")]
        [Required(ErrorMessage = "Informe a categoria do produto")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        [Display(Name = "Usuário")]
        public virtual Usuario Usuario { get; set; }
    }
}
