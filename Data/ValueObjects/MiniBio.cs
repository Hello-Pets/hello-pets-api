using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class MiniBio : ValueObject, IEquatable<MiniBio>
{
    public string Description { get; private set; } = string.Empty;

    [JsonConstructor]
    public MiniBio(string description)
    {
        Validate(description);

        Description = description.Trim();
    }

    private MiniBio() {}

    public void Validate(string description) {
        description = description.Trim();

        if(description.Length < 1 || description.Length > 100) throw new ArgumentException("Mini bio must contain between 1 and 100 characters");
    }

    public static implicit operator string(MiniBio description) => description.ToString();

    public static implicit operator MiniBio(string description) => new MiniBio(description);

    public override string ToString() => Description;

    public override int GetHashCode() => Description.GetHashCode();

    public bool Equals(MiniBio? biography) => Description == biography?.Description;
}