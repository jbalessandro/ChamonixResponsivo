using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class ContaParcela
    {
        [Key]
        public int ContaParcelaId { get; set; }

        [Display(Name ="Vencimento")]
        public DateTime Vencto { get; set; }

        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        [Display(Name ="Pago ?")]
        public bool Pago { get; set; }

        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        [Display(Name ="Pago em")]
        public DateTime? PagoEm { get; set; }

        [Display(Name ="Desconto")]
        public decimal Desconto { get; set; }

        [Display(Name ="Juros")]
        public decimal Juros { get; set; }

        [Display(Name ="Total pago")]
        public decimal TotalPago { get; set; }

        [Display(Name ="Conta")]
        [Range(1,double.MaxValue, ErrorMessage ="Conta inválida")]
        public int ContaId { get; set; }

        [Display(Name = "Conta pagamento")]
        public int? ContaBancariaId { get; set; }

        [Display(Name ="Usuário")]
        public virtual Usuario Usuario { get; set; }

        public virtual Conta Conta { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; }
    }
}