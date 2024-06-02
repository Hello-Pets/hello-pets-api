using System.Security.Cryptography;
using System.Text;

namespace HelloPets.Data.ValueObjects;

public class Password : ValueObject, IEquatable<Password>
{
    public string Hash { get; private set; } = null!;
    public byte[] Salt { get; private set; } = null!;

    private Password() {}

    public Password(string password)
    {
        Salt = RandomNumberGenerator.GetBytes(16);
        Hash = CreateHash(password);
    }

    public string CreateHash(string password) {
        using (var sha256 = SHA256.Create()) {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[Salt.Length + passwordBytes.Length];
            Buffer.BlockCopy(Salt, 0, saltedPassword, Salt.Length, passwordBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, Salt.Length, passwordBytes.Length);
            byte[] hash = sha256.ComputeHash(saltedPassword);
            string hashedPassword = Convert.ToBase64String(hash);

            return hashedPassword;
        }
    }

    public bool CompareHashs(string password) {
        using (var sha256 = SHA256.Create()) {
            byte[] inputSalt = Salt;
            byte[] inputPasswordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedInputPassword = new byte[inputSalt.Length + inputPasswordBytes.Length];
            Buffer.BlockCopy(inputSalt, 0, saltedInputPassword, 0, inputSalt.Length);
            Buffer.BlockCopy(inputPasswordBytes, 0, saltedInputPassword, inputSalt.Length, inputPasswordBytes.Length);
            byte[] inputHash = sha256.ComputeHash(saltedInputPassword);
            string inputHashedPassword = Convert.ToBase64String(inputHash);

            return inputHashedPassword == Hash;
        }
    }

    public static implicit operator string(Password password) => password.ToString();

    public static implicit operator Password(string password) => new Password(password);

    public override string ToString() => Hash;

    public override int GetHashCode() => Hash.GetHashCode();

    public bool Equals(Password? other) => Hash == other?.Hash;
}