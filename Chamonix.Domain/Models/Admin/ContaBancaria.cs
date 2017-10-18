using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class ContaBancaria
    {
        [Key]
        public int ContaBancariaId { get; set; }

        [Display(Name = "Nome conta")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [Required(ErrorMessage ="Informe o nome da conta")]
        public string Descricao { get; set; }

        [Display(Name = "Código do banco")]
        [Range(1,double.MaxValue, ErrorMessage ="Código do banco inválido")]
        public int CodigoBanco { get; set; }

        [Display(Name = "Nome banco")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [Required(ErrorMessage ="Informe o nome do banco")]
        public string NomeBanco { get; set; }

        [Display(Name = "Agência")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage ="Informe a agência")]
        public string Agencia { get; set; }

        [Display(Name = "Número conta")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [Required(ErrorMessage ="Informe a conta")]
        public string Conta { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage ="Informe o saldo")]
        public decimal Saldo { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Informe o telefone da agência")]
        public string Telefone { get; set; }

        [Display(Name = "Observações")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

    }
}
