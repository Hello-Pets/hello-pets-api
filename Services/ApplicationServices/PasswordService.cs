using System.Security.Cryptography;
using System.Text;
using HelloPets.Services.ApplicationServices.Interfaces;

namespace HelloPets.Services.ApplicationServices;

public class PasswordService : IPasswordService
{   
    public string CreateHash(string password, out byte[] salt)
    {
        using (var sha = SHA256.Create())
        {
            //Gera um salt aleatorio
            salt = GenerateSalt();
            //Combina a senha com o salt
            var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
            var hash = sha.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hash);
        }
    }
    public bool CompareHashs(string passwordInput, string passwordStored, byte[] saltStored)
    {
        using (var sha256 = SHA256.Create())
        {
            //Combina o salt armazenado junto com a senha de entrada
            var saltedInputPassword = Encoding.UTF8.GetBytes(passwordInput).Concat(saltStored).ToArray();
            //Cria o hash
            var inputHash = sha256.ComputeHash(saltedInputPassword);
            var inputHashPassword = Convert.ToBase64String(inputHash);
            return inputHashPassword == passwordStored;
        }

    }
    //Gerar salt criptografado
    private byte[] GenerateSalt()
    {
        //Gera numeros aleatorios de alta qualidade criptografica
        using (var rng = new RNGCryptoServiceProvider())
        {
            var salt = new byte[16];
            //Gera os bytes (numeros aleatorios)
            rng.GetBytes(salt);
            return salt;
        }
    }

    //public string CreateHash(string password)
    //{
    //    using (var sha = SHA256.Create())
    //    {
    //        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

    //        var builder = new StringBuilder();

    //        foreach (var b in bytes)
    //            builder.Append(b.ToString("x2"));

    //        return builder.ToString();
    //    }
    //}

    //public bool CompareHashs(string passwordInput, string storedPassword, byte[] storedSalt)
    //{
    //    using (var sha256 = SHA256.Create()) {
    //        byte[] inputSalt = storedSalt;
    //        byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(passwordInput);
    //        byte[] saltedInputPassword = new byte[inputSalt.Length + inputPasswordBytes.Length];
    //        Buffer.BlockCopy(inputSalt, 0, saltedInputPassword, 0, inputSalt.Length);
    //        Buffer.BlockCopy(inputPasswordBytes, 0, saltedInputPassword, inputSalt.Length, inputPasswordBytes.Length);
    //        byte[] inputHash = sha256.ComputeHash(saltedInputPassword);
    //        string inputHashedPassword = Convert.ToBase64String(inputHash);

    //        return ConstantTimeEquals(inputHash, Convert.FromBase64String(storedPassword));
    //    }
    //}

    //public static bool ConstantTimeEquals(byte[] a, byte[] b)
    //{
    //    if (a.Length != b.Length)
    //    {
    //        return false;
    //    }

    //    int result = 0;
    //    for (int i = 0; i < a.Length; i++)
    //    {
    //        result |= a[i] ^ b[i];
    //    }

    //    return result == 0;
    //}
}