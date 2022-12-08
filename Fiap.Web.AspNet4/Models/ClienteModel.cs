using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet4.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 70 caracteres.")]
        [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O email do cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite o email no formato válido")]
        public string? Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento incorreta")]
        //[Range(typeof(DateTime), DateTime.Now, "", ErrorMessage = "Data incorreta" )]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        public string? Observacao { get; set; }


        //FK
        [Display(Name = "Representante")]
        public int RepresentanteId { get; set; }

        //Navigation Object
        [ForeignKey("RepresentanteId")]
        public RepresentanteModel? Representante { get; set; }

    }
}
