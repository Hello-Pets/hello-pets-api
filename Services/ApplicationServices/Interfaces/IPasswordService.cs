namespace HelloPets.Services.ApplicationServices.Interfaces;

public interface IPasswordService
{
    public string CreateHash(string password);

    public bool ComparePassword(string passwordInput, string storedPassword, string storedSalt);
}