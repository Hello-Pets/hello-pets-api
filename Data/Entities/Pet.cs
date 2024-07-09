using Data.Enums;

namespace HelloPets.Data.Entities
{
    public class Pet : Entity
    {
        public string Nickname { get; private set; }
        public string Furcolor { get; private set; }
        public bool Neutered { get; private set; }
        public bool HasMicroChip { get; private set; }
        public Size Size { get; private set; }
        public int BreedId { get; private set; }
        public virtual Breed Breed { get; private set; }
        public virtual ICollection<Tutor> Tutors { get; private set; }
        public virtual ICollection<Trait> Traits { get; private set; }
        public virtual ICollection<Preference> Preferences { get; private set; }
        public virtual ICollection<SpecialNeeds> SpecialNeeds { get; private set; }
        public virtual ICollection<UserPets> UserPets { get; private set; }

        private Pet() { }

        public Pet(int id, string name, string document, string documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string nickname, string furcolor, string bio, DateTime birthdate, bool neutered, bool hasMicroChip, int profileImageId, string size, int breedId, Breed breed, List<Tutor> tutors, List<Trait> traits, List<Preference> preferences, List<SpecialNeeds> specialNeeds, ICollection<UserPets> userPets, HelloPetsFile file) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId, file)
        {
            Nickname = nickname;
            Furcolor = furcolor;
            Neutered = neutered;
            HasMicroChip = hasMicroChip;
            Size = size;
            BreedId = breedId;
            Breed = breed;
            Tutors = tutors;
            Traits = traits;
            Preferences = preferences;
            SpecialNeeds = specialNeeds;
            UserPets = userPets;
        }
    }
}
