namespace HelloPets.Services.ApplicationServices.Interfaces;

public interface IPasswordService
{

    public string CreateHash(string password, out byte[] salt);

    public bool CompareHashs(string passwordInput, string passwordStored, byte[] saltStored);
    //public string CreateHash(string password);

    //public bool CompareHashs(string passwordInput, string storedPassword, byte[] storedSalt);
}