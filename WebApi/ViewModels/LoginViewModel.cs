using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public record LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
