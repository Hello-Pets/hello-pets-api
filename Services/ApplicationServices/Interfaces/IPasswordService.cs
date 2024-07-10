namespace HelloPets.Services.Application_Services.Interfaces;

public interface IPasswordService
{
    public string CreateHash(string password);

    public bool CompareHashs(string passwordInput, string storedPassword, byte[] storedSalt);
}