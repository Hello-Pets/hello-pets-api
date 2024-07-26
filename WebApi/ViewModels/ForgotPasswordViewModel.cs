using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public record ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
    }
}
