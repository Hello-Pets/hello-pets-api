using HelloPets.Data.Enums;

namespace HelloPets.WebApi.ViewModels;

public record ReturnUserViewModel
{
    public string PublicId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public UserType UserType { get; set; }

    public string Token { get; set; }
}