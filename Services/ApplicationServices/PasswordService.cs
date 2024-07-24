using System.Security.Cryptography;
using System.Text;
using HelloPets.Services.ApplicationServices.Interfaces;

namespace HelloPets.Services.ApplicationServices;

public class PasswordService : IPasswordService
{
    public string CreateHash(string password)
    {
        using (var sha = SHA256.Create())
        {
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            var builder = new StringBuilder();

            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }

    public bool ComparePassword(string passwordInput, string storedPassword, string storedSalt)
    {
        var inputHash = CreateHash(passwordInput + storedSalt);

        return inputHash == storedPassword;
    }
}