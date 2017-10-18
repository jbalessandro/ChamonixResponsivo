using System;
using System.ComponentModel.DataAnnotations;

namespace Chamonix.Domain.Models.Admin
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }

        [Display(Name ="Nome fantasia")]
        [Required(ErrorMessage ="Informe o nome fantasia")]
        [StringLength(40, ErrorMessage ="O nome fantasia é composto por no máximo 40 caracteres")]
        public string Fantasia { get; set; }

        [Display(Name ="Razão social")]
        [StringLength(100, ErrorMessage ="A razão social é composta por no máximo 100 caracteres")]
        public string RazaoSocial { get; set; }

        [Display(Name ="CNPJ")]
        [StringLength(14, ErrorMessage ="O CNPJ é composto por no máximo 14 caracteres")]
        public string Cnpj { get; set; }

        [Display(Name ="Inscrição Estadual")]
        [StringLength(12, ErrorMessage ="A inscrição estadual é composta por no máximo 12 caracteres")]
        public string Ie { get; set; }

        [Display(Name ="Endereço")]
        [StringLength(100, ErrorMessage ="Máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(100, ErrorMessage = "Máximo 60 caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(60, ErrorMessage = "Máximo 100 caracteres")]
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        public int EstadoId { get; set; }

        [Display(Name ="CEP")]
        [StringLength(8, ErrorMessage ="Máximo 8 caracteres")]
        public string Cep { get; set; }

        [Display(Name ="Telefone")]
        [StringLength(100, ErrorMessage ="Máximo 100 caracteres")]
        public string Telefone { get; set; }

        [Display(Name ="Email")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool Ativo { get; set; }

        [Display(Name ="Alterado em")]
        [DataType(DataType.Date)]
        public DateTime AlteradoEm { get; set; }

        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        [Range(1,double.MaxValue, ErrorMessage ="Selecione o ramo de atividade")]
        public int RamoId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Ramo Ramo { get; set; }
        public virtual Estado Estado { get; set; }
    }
}