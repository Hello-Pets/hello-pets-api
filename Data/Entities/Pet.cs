using HelloPets.Data.Enums;
using HelloPets.Data.ValueObjects;

namespace HelloPets.Data.Entities;

public class Pet : Entity
{
    // Discutir se Pet deve ter nome ou somente apelido. (explicar motivos: V.O so permite nome com sobrenome)
    //public Name Name { get; private set; } = null!;
    public string Photo { get; private set; } = string.Empty;
    public Document Document { get; private set; } = null!;
    public DateTime BirthDate { get; private set; } = new DateTime();
    public PreferencesAndDislikes PreferencesAndDislikes { get; private set; } = new PreferencesAndDislikes();
    public Specie Specie { get; private set; } = new Specie();
    public Nickname Nickname { get; private set; } = new Nickname(string.Empty);
    public Biography Biography { get; private set; } = new Biography();
    public PetsCoatsEnum PetsCoats { get; private set; } = PetsCoatsEnum.Other;
    public BodyMetrics BodyMetrics { get; private set; } = new BodyMetrics();
    public PersonalitiesEnum Personality { get; private set; } = PersonalitiesEnum.Other;
    public bool Neutered { get; private set; } = false;
    public bool HasMicrochip { get; private set; } = false;
    public bool SpecialNeeds { get; private set; } = false;

    public void UpdatePet(List<string>? preferences, List<string>? dislikes, string? photo, int? documentTypeEnum, string? documentNumber, DateTime? birthDate, int? petSpecie, string? petBreed, string? nickName, string? biography, int? petsCoats, decimal? height, decimal? length, decimal? weight, int? personality, bool? neutered, bool? hasMicrochip, bool? specialNeeds) {
        Photo = photo ?? Photo;
        if (documentNumber != null && documentTypeEnum != null) Document = new Document(documentNumber, documentTypeEnum.Value);
        else Document = Document;

        BirthDate = birthDate ?? BirthDate;
        if(preferences != null && dislikes != null) PreferencesAndDislikes = new PreferencesAndDislikes(preferences, dislikes);
        else PreferencesAndDislikes = PreferencesAndDislikes;

        if(petSpecie != null && petBreed != null) Specie = new Specie(petSpecie.Value, petBreed);
        else Specie = Specie;

        if(nickName != null) Nickname = new Nickname(nickName);
        else Nickname = Nickname;

        if(biography != null) Biography = new Biography(biography);
        else Biography = Biography;

        if(height != null && length != null && weight != null) BodyMetrics = new BodyMetrics(height.Value, length.Value, weight.Value);
        else BodyMetrics = BodyMetrics;

        Neutered = neutered ?? Neutered;
        HasMicrochip = hasMicrochip ?? HasMicrochip;
        SpecialNeeds = specialNeeds ?? SpecialNeeds;

        PetsCoats = petsCoats.HasValue && Enum.IsDefined(typeof(PetsCoatsEnum), petsCoats.Value) ? (PetsCoatsEnum) petsCoats.Value : PetsCoatsEnum.Other;
        Personality = personality.HasValue && Enum.IsDefined(typeof(PersonalitiesEnum), personality) ? (PersonalitiesEnum) personality.Value : PersonalitiesEnum.Other;
    }
}