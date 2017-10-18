using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }

        [Display(Name ="Data Pedido")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Informe a data do pedido")]
        public DateTime PedidoEm { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }

        [Range(1,double.MaxValue, ErrorMessage ="Selecione o fornecedor")]
        public int FornecedorId { get; set; }

        [Range(1,double.MaxValue, ErrorMessage ="Selecione a categoria")]
        public int ContaCategoriaId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ContaCategoria ContaCategoria { get; set; }
        public virtual IEnumerable<ContaParcela> ContaParcela { get; set; }
    }
}
