using System.Security.Cryptography;
using HelloPets.Application.Services.Interfaces;

namespace HelloPets.Data.ValueObjects;

public class Password : ValueObject, IEquatable<Password>
{
    public string Hash { get; private set; } = null!;
    public byte[] Salt { get; private set; } = null!;

    private Password() {}

    public Password(string password, IPasswordService passwordService)
    {
        Salt = RandomNumberGenerator.GetBytes(16);
        Hash = passwordService.CreateHash(password);
    }

    public static implicit operator string(Password password) => password.ToString();

    public override string ToString() => Hash;

    public override int GetHashCode() => Hash.GetHashCode();

    public bool Equals(Password? other) => Hash == other?.Hash;
}