using HelloPets.Data.Enums;
using HelloPets.Data.ValueObjects;

namespace HelloPets.Data.Entities;

public class Pet : Entity
{
    // Discutir se Pet deve ter nome ou somente apelido. (explicar motivos: V.O so permite nome com sobrenome)
    //public Name Name { get; private set; } = null!;
    public Nickname Nickname { get; private set; } = null!;
    public string Photo { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    public PreferencesAndDislikes PreferencesAndDislikes { get; private set; } = null!;
    public Specie Specie { get; private set; } = null!;
    public MiniBio MiniBio { get; private set; } = null!;
    public PetsCoatsEnum PetsCoatsEnum { get; private set; }
    public BodyMetrics BodyMetrics { get; private set; } = null!;
    public PersonalitiesEnum Personality { get; private set; }
    public bool Neutered { get; private set; }
    public bool HasMicrochip { get; private set; }
    public bool SpecialNeeds { get; private set; }

    private Pet() {}

    public Pet(string nickname, string photo, int documentTypeEnum, string documentNumber, DateTime birthDate, List<string> preferences, List<string> dislikes, int petSpecieEnum, string petBreed, string miniBio, int petsCoatsEnum, decimal height, decimal lenght, decimal weight, int personality, bool neutered = false, bool hasMicrochip = false, bool specialNeeds = false)
    {
        Validate(nickname, photo, documentTypeEnum, documentNumber, birthDate, preferences, dislikes, petSpecieEnum, petBreed, miniBio, petsCoatsEnum, height, lenght, weight);

        Nickname = new Nickname(nickname);
        Photo = photo;
        Document = new Document(documentTypeEnum, documentNumber);
        BirthDate = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
        PreferencesAndDislikes = new PreferencesAndDislikes(preferences, dislikes);
        Specie = new Specie(petSpecieEnum, petBreed);
        MiniBio = new MiniBio(miniBio);
        PetsCoatsEnum = Enum.IsDefined(typeof(PetsCoatsEnum), petsCoatsEnum) ? (PetsCoatsEnum)petsCoatsEnum : PetsCoatsEnum.Other;
        BodyMetrics = new BodyMetrics(height, lenght, weight);
        Personality = Enum.IsDefined(typeof(PersonalitiesEnum), personality) ? (PersonalitiesEnum)personality : PersonalitiesEnum.Other;
        Neutered = neutered;
        HasMicrochip = hasMicrochip;
        SpecialNeeds = specialNeeds;
    }

    private void Validate(string nickname, string photo, int documentTypeEnum, string documentNumber, DateTime birthDate, List<string> preferences, List<string> dislikes, int petSpecieEnum, string petBreed, string miniBio, int petsCoatsEnum, decimal height, decimal lenght, decimal weight)
    {
        _ = new Nickname(nickname);
        if (photo.Length < 0 || photo.Length > 255) throw new ArgumentException("Photo must contain between 0 and 255 characters");
        _ = new Document(documentTypeEnum, documentNumber);
        if (birthDate < new DateTime(1833, 5, 8)) throw new ArgumentException("Birthdate cannot be inferior than Jonathan (search for 'Older animal alive')");
        _ = new PreferencesAndDislikes(preferences, dislikes);
        _ = new Specie(petSpecieEnum, petBreed);
        _ = new MiniBio(miniBio);
        _ = new BodyMetrics(height, lenght, weight);
    }

    public void UpdatePet(List<string>? preferences, List<string>? dislikes, string? photo, int? documentTypeEnum, string? documentNumber, DateTime? birthDate, int? petSpecieEnum, string? petBreed, string? nickName, string? miniBio, int? petsCoatsEnum, decimal? height, decimal? length, decimal? weight, int? personality, bool? neutered, bool? hasMicrochip, bool? specialNeeds) {
        Photo = photo ?? Photo;
        if (documentNumber != null && documentTypeEnum != null) Document = new Document(documentTypeEnum.Value, documentNumber);
        else Document = Document;

        BirthDate = birthDate ?? BirthDate;
        if(preferences != null && dislikes != null) PreferencesAndDislikes = new PreferencesAndDislikes(preferences, dislikes);
        else PreferencesAndDislikes = PreferencesAndDislikes;

        if(petSpecieEnum != null && petBreed != null) Specie = new Specie(petSpecieEnum.Value, petBreed);
        else Specie = Specie;

        if(nickName != null) Nickname = new Nickname(nickName);
        else Nickname = Nickname;

        if(miniBio != null) MiniBio = new MiniBio(miniBio);
        else MiniBio = MiniBio;

        if(height != null && length != null && weight != null) BodyMetrics = new BodyMetrics(height.Value, length.Value, weight.Value);
        else BodyMetrics = BodyMetrics;

        Neutered = neutered ?? Neutered;
        HasMicrochip = hasMicrochip ?? HasMicrochip;
        SpecialNeeds = specialNeeds ?? SpecialNeeds;

        PetsCoatsEnum = petsCoatsEnum.HasValue && Enum.IsDefined(typeof(PetsCoatsEnum), petsCoatsEnum.Value) ? (PetsCoatsEnum) petsCoatsEnum.Value : PetsCoatsEnum.Other;
        Personality = personality.HasValue && Enum.IsDefined(typeof(PersonalitiesEnum), personality) ? (PersonalitiesEnum) personality.Value : PersonalitiesEnum.Other;
    }
}