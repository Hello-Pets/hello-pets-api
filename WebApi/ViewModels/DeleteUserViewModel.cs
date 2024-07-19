using System.ComponentModel.DataAnnotations;

namespace HelloPets.WebApi.ViewModels;

public record DeleteUserViewModel
{
    [Required(ErrorMessage = "ID deve ser fornecido.")]
    public int Id { get; set; }
}