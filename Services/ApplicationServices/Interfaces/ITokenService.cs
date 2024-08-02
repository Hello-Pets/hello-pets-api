using HelloPets.Data.Entities;

namespace HelloPets.Services.ApplicationServices.Interfaces;

public interface ITokenService
{
    public string Generate(User user, TimeSpan timeSpan);
    public int GetUserIdFromToken();
}