using System.Text.Json.Serialization;
using HelloPets.Data.Enums;

namespace HelloPets.Data.ValueObjects;

public class Specie : ValueObject, IEquatable<Specie>
{
    public SpecieEnum PetSpecie { get; private set; }
    public string Breed { get; private set; } = null!;

    [JsonConstructor]
    public Specie(int petSpecie, string breed = "")
    {
        Validate(petSpecie, breed);

        PetSpecie = (SpecieEnum)petSpecie;
        Breed = breed.Trim();
    }

    private Specie() {}

    private void Validate(int petSpecie, string breed)
    {
        breed = breed.Trim();

        if(!Enum.IsDefined(typeof(SpecieEnum), petSpecie)) throw new ArgumentException("Invalid pet specie");

        if(breed.Length < 3 || breed.Length > 20) throw new ArgumentException("Breed must be between 3 and 20 characters");

        if(breed.Any(ch => char.IsDigit(ch))) throw new ArgumentException("Breed cannot contain digit");

        if(breed.Any(ch => char.IsPunctuation(ch))) throw new ArgumentException("Breed cannot contain pontuaction");
    }

    public override string ToString() => Breed;

    public override int GetHashCode() => Breed.GetHashCode();

    public bool Equals(Specie? specie) => Breed == specie?.Breed;
}