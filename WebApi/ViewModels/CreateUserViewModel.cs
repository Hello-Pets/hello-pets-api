using System.ComponentModel.DataAnnotations;
using HelloPets.Data.Enums;

namespace HelloPets.WebApi.ViewModels;

public record CreateUserViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string EmailVerification { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MinLength(6, ErrorMessage = "Senha deve conter mais que 6 caracteres")]
    public string Password { get; set; } = null!;

    public string? Document { get; set; }

    public Guid Salt { get; } = Guid.NewGuid();

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public UserType UserType { get; set; }
}