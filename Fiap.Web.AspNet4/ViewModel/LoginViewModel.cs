using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet4.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public int UsuarioId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do nome é de 50 caracteres!")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de dois caracteres")]
        public string? UsuarioEmail { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(12, ErrorMessage = "O tamanho máximo eh 12 caracteres!")]
        [MinLength(5, ErrorMessage = "Digite cinco caracteres")]
        public string? UsuarioSenha { get; set; }
    }
}
