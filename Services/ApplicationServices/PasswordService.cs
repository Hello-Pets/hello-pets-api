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

    public bool ComparePassword(string inputPassword, string storedPassword, string storedSalt)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputSaltBytes = Convert.FromBase64String(storedSalt);
            byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(inputPassword);

            byte[] saltedInputPassword = new byte[inputSaltBytes.Length + inputPasswordBytes.Length];
            Buffer.BlockCopy(inputSaltBytes, 0, saltedInputPassword, 0, inputSaltBytes.Length);
            Buffer.BlockCopy(inputPasswordBytes, 0, saltedInputPassword, inputSaltBytes.Length, inputPasswordBytes.Length);

            byte[] inputHash = sha256.ComputeHash(saltedInputPassword);

            return ConstantTimeEquals(inputHash, Convert.FromBase64String(storedPassword));
        }
    }

    public static bool ConstantTimeEquals(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }

        int result = 0;
        for (int i = 0; i < a.Length; i++)
        {
            result |= a[i] ^ b[i];
        }

        return result == 0;
    }
}