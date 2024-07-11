using HelloPets.Data.Entities;

namespace HelloPets.Services.ApplicationServices.Interfaces;

public interface ITokenService
{
    public string Generate(Tutor tutor);
    public int GetUserIdFromToken();
}