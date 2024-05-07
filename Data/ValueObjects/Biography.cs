using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class Biography : ValueObject, IEquatable<Biography>
{
    public string Description { get; private set; } = string.Empty;

    [JsonConstructor]
    public Biography(string description)
    {
        Validate(description);

        Description = description.Trim();
    }

    public Biography() {}

    public void Validate(string description) {
        description = description.Trim();

        if(description.Length < 1 || description.Length > 100) throw new ArgumentException("Description must contain between 1 and 100 characters");
    }

    public static implicit operator string(Biography description) => description.ToString();

    public static implicit operator Biography(string description) => new Biography(description);

    public override string ToString() => Description;

    public override int GetHashCode() => Description.GetHashCode();

    public bool Equals(Biography? biography) => Description == biography?.Description;
}