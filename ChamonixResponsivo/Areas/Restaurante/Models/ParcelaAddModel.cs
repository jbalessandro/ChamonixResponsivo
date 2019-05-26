using System;
using System.ComponentModel.DataAnnotations;

namespace ChamonixResponsivo.Areas.Restaurante.Models
{
    public enum Periodicidade
    {
        Mensal = 1,
        Semanal = 7,
        Quinzenal = 15,
        Bimestral = 2,
        Trimestral = 3,
        Semestral = 6,
        Anual = 12,
        Nenhuma = 0
    }

    public class ParcelaAddModel
    {
        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Vencto { get; set; }

        [Required(ErrorMessage = "Informe o valor da parcela")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da parcela não pode ser negativo")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Número parcelas")]
        [Range(1, 300, ErrorMessage = "O número de parcelas varia entre 1 e 300 na inclusão")]
        public int Parcelas { get; set; }

        public Periodicidade Periodicidade { get; set; }
    }
}