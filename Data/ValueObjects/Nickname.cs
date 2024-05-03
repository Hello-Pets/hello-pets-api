
using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class Nickname : ValueObject, IEquatable<Nickname>
{
    public string Name { get; private set; } = string.Empty;

    [JsonConstructor]
    public Nickname(string nickname)
    {
        Validate(nickname);

        Name = nickname.Trim();
    }


    private Nickname() {}

    private void Validate(string nickname)
    {
        nickname = nickname.Trim();

        if(nickname is null) throw new NullReferenceException("Nickname cannot be null");

        if(nickname.Length < 2 || nickname.Length > 20) throw new ArgumentException("Nickname must contain between 2 and 20 characters");
    }

    public static implicit operator string(Nickname nickname) => nickname.ToString();

    public static implicit operator Nickname(string nickname) => new Nickname(nickname);

    public override string ToString() => Name.ToString();

    public override int GetHashCode() => Name.GetHashCode();

    public bool Equals(Nickname? nickname) => Name == nickname?.Name;
}