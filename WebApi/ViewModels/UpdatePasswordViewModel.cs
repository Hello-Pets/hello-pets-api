using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public record UpdatePasswordViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo 6 caracteres.")]
        public string PasswordVerification { get; set; }
    }
}
