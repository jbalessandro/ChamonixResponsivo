using System.ComponentModel.DataAnnotations;

namespace ChamonixResponsivo.Models
{
    public class ContatoViewModels
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Informe seu nome")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Informe seu e-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Informe um email válido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Digite sua mensagem")]
        [DataType(DataType.MultilineText)]
        public string Mensagem { get; set; }
    }
}