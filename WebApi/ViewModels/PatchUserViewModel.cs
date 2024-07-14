namespace HelloPets.WebApi.ViewModels;

public record PatchUserViewModel 
{
    public string? Bio { get; set; }

    public string? Address { get; set; }

    public int? ProfileImageId { get; set; }
}