using System.ComponentModel.DataAnnotations;

namespace ChamonixResponsivo.Areas.Restaurante.Models
{
    public class LoginUsuario
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}