using System.ComponentModel.DataAnnotations;

namespace HelloPets.WebApi.ViewModels;

public record PatchUserViewModel 
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Id { get; set; }

    public string? Bio { get; set; }

    public string? Address { get; set; }

    public int? FileId { get; set; }
}