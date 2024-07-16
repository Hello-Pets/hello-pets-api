using System.ComponentModel.DataAnnotations;
using HelloPets.Data.Enums;

namespace HelloPets.WebApi.ViewModels;

public record CreateUserViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3, 30, ErrorMessage = "O campo {0} precisa conter entre 3 e 30 caracteres.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido."),
    MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo 6 caracteres.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório."), 
    MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo 6 caracteres.")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório."), 
    MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo 6 caracteres.")]
    public string PasswordVerification { get; set; } = null!;

    public Guid Salt { get; set; } = Guid.NewGuid();

    public DocumentType DocumentType { get; set; }

    public string? Document { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public UserType UserType { get; set; }
}