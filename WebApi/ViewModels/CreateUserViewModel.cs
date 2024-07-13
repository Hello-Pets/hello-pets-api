using System.ComponentModel.DataAnnotations;
using HelloPets.Data.Enums;

namespace HelloPets.WebApi.ViewModels;

public record CreateUserViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string EmailVerification = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(6, 18, ErrorMessage = "Senha deve conter entre 6 e 18 caracteres")]
    public string Password = null!;

    public string? Document;

    public Guid Salt { get; } = Guid.NewGuid();

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public UserType UserType;
}