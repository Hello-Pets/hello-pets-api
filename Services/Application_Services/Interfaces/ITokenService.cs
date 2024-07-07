using Data.Entities;

namespace Services.Application_Services.Interfaces;

public interface ITokenService
{
    public string Generate(Tutor tutor);
    public int GetUserIdFromToken();
}