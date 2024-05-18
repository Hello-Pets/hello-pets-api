using System.Globalization;
using System.Text.Json.Serialization;

namespace HelloPets.Data.ValueObjects;

public class Name : ValueObject, IEquatable<Name>
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    [JsonConstructor]
    public Name(string firstName, string lastName)
    {
        Validate(firstName, lastName);

        FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName.Trim());
        LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName.Trim());
    }

    private Name() {}

    public void Validate(string firstName, string lastName) 
    {
        firstName = firstName.Trim();
        lastName = lastName.Trim();

        if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) throw new Exception("First name or last name cannot be empty or null");

        if(firstName.Length < 3 || lastName.Length < 3) throw new Exception("First name and last name must be greather than 2 characters");

        if(firstName.Length > 99 || lastName.Length > 99) throw new Exception("First name and last name must be less than 100 characters");

        if(firstName.Any(ch => char.IsPunctuation(ch)) || lastName.Any(ch => char.IsPunctuation(ch))) throw new Exception("First name and last name cannot contain pontuaction");

        if(firstName.Any(ch => char.IsDigit(ch)) || lastName.Any(ch => char.IsDigit(ch))) throw new Exception("First name and last name cannot contain digit");

        if (firstName.Any(ch => !char.IsLetter(ch)) || lastName.Any(ch => !char.IsLetter(ch))) throw new Exception("First name and last name cannot contain special characters");
    }

    public static implicit operator string(Name name) => name.ToString();

    public static implicit operator Name(string fullname) 
    {
        var parts = fullname.Split(" ");

        if(parts.Length < 2) throw new Exception("Name must contain first and last name");

        return new Name(parts[0], parts[1]);
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public override int GetHashCode() => (FirstName + LastName).GetHashCode();

    public bool Equals(Name? name) => FirstName == name?.FirstName && LastName == name.LastName;
}