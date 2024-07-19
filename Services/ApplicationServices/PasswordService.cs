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

    public bool CompareHashs(string passwordInput, string storedPassword, byte[] storedSalt)
    {
        using (var sha256 = SHA256.Create()) {
            byte[] inputSalt = storedSalt;
            byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(passwordInput);
            byte[] saltedInputPassword = new byte[inputSalt.Length + inputPasswordBytes.Length];
            Buffer.BlockCopy(inputSalt, 0, saltedInputPassword, 0, inputSalt.Length);
            Buffer.BlockCopy(inputPasswordBytes, 0, saltedInputPassword, inputSalt.Length, inputPasswordBytes.Length);
            byte[] inputHash = sha256.ComputeHash(saltedInputPassword);
            string inputHashedPassword = Convert.ToBase64String(inputHash);

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