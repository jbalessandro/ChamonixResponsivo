using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="Informe o nome do usuário")]
        [Display(Name = "Nome do usuário")]
        [StringLength(100,ErrorMessage ="O nome do usuário é composto por no máximo 100 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Informe o logon do usuário")]
        [Display(Name = "Logon")]
        [StringLength(20, ErrorMessage ="O logon do usuário é composto por no máximo 20 caracteres")]
        public string Logon { get; set; }

        [Required(ErrorMessage = "Informe a senha para acesso")]
        [Display(Name = "Senha")]
        [StringLength(20, ErrorMessage = "A senha é composta por no máximo 20 caracteres")]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Alterado Em")]
        public DateTime AlteradoEm { get; set; }

        [Display(Name ="Cargo")]
        public int CargoId { get; set; }

        [Display(Name = "Cargo")]
        public virtual Cargo Cargo { get; set; }
    }
}
