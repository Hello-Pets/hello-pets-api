namespace HelloPets.Services.ApplicationServices.Interfaces;

public interface IPasswordService
{
    public string CreateHash(byte[] inputBytes);

    public bool ComparePassword(string passwordInput, string storedPassword, Guid storedSalt);
}