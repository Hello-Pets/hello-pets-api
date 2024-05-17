
using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class Nickname : ValueObject, IEquatable<Nickname>
{
    public string Name { get; private set; } = null!;

    [JsonConstructor]
    public Nickname(string nickname)
    {
        Validate(nickname.Trim());

        Name = nickname.Trim();
    }


    private Nickname() {}

    private void Validate(string nickname)
    {
        if(string.IsNullOrEmpty(nickname)) throw new ArgumentException("Nickname cannot be null or empty");

        if(nickname.Length < 2 || nickname.Length > 20) throw new ArgumentException("Nickname must contain between 2 and 20 characters");

        if(nickname.Any(c => char.IsPunctuation(c)) || nickname.Any(c => char.IsDigit(c))) throw new ArgumentException("Nickname cannot contain digit or pontuaction");
    }

    public static implicit operator string(Nickname nickname) => nickname.ToString();

    public static implicit operator Nickname(string nickname) => new Nickname(nickname);

    public override string ToString() => Name.ToString();

    public override int GetHashCode() => Name.GetHashCode();

    public bool Equals(Nickname? nickname) => Name == nickname?.Name;
}