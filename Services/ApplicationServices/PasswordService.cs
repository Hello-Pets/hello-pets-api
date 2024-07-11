using System.Security.Cryptography;
using System.Text;
using HelloPets.Services.ApplicationServices.Interfaces;

namespace HelloPets.Services.ApplicationServices;

public class PasswordService : IPasswordService
{   
    public string CreateHash(string password)
    {
        using (var sha256 = SHA256.Create()) {
            var salt = RandomNumberGenerator.GetBytes(16);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];
            Buffer.BlockCopy(salt, 0, saltedPassword, salt.Length, passwordBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);
            byte[] hash = sha256.ComputeHash(saltedPassword);
            string hashedPassword = Convert.ToBase64String(hash);

            return hashedPassword;
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