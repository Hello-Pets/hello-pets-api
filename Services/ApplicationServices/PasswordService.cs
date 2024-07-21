using System.Security.Cryptography;
using System.Text;
using HelloPets.Services.ApplicationServices.Interfaces;

namespace HelloPets.Services.ApplicationServices;

public class PasswordService : IPasswordService
{
    public string CreateHash(byte[] inputBytes)
    {
        using (var sha = SHA256.Create())
        {
            var bytes = sha.ComputeHash(inputBytes);
            var builder = new StringBuilder();

            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }
    public string CreateHash(string password)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        return CreateHash(inputBytes);
    }

    public bool ComparePassword(string inputPassword, string storedPassword, Guid storedSalt)
    {
        byte[] storedSaltBytes = storedSalt.ToByteArray();
        byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(inputPassword);

        byte[] arrayInputSaltedPassword = new byte[storedSaltBytes.Length + inputPasswordBytes.Length];
        Buffer.BlockCopy(storedSaltBytes, 0, arrayInputSaltedPassword, 0, storedSaltBytes.Length);
        Buffer.BlockCopy(inputPasswordBytes, 0, arrayInputSaltedPassword, storedSaltBytes.Length, inputPasswordBytes.Length);

        string inputPasswordSaltedAndHashed = CreateHash(arrayInputSaltedPassword);

        return Equals(inputPasswordSaltedAndHashed, storedPassword);
    }
}