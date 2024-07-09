using Data.ValueObjects;
using HelloPets.Data.Entities;

namespace Data.Entities
{
    public class Pet : Entity
    {
        public string Nickname { get; private set; }
        public string Furcolor { get; private set; }
        public bool Neutered { get; private set; }
        public bool HasMicroChip { get; private set; }
        public int FileId { get; set; }
        public virtual HelloPetsFile ProfileImage { get; set; }
        public string Size { get; private set; }
        public int BreedId { get; private set; }
        public Breed Breed { get; private set; }
        public virtual List<Tutor> Tutors { get; private set; }
        public virtual List<Trait> Traits { get; private set; }
        public virtual List<Preference> Preferences { get; private set; }
        public virtual List<SpecialNeeds> SpecialNeeds { get; private set; }
        public virtual ICollection<UserPets> UserPets { get; private set; }

        private Pet() { }

        public Pet(int id, string name, string document, string documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string nickname, string furcolor, string bio, DateTime birthdate, bool neutered, bool hasMicroChip, int profileImageId, int fileId, HelloPetsFile profileImage, string size, int breedId, Breed breed, List<Tutor> tutors, List<Trait> traits, List<Preference> preferences, List<SpecialNeeds> specialNeeds, ICollection<UserPets> userPets, HelloPetsFile file) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId, file)
        {
            Nickname = nickname;
            Furcolor = furcolor;
            Neutered = neutered;
            HasMicroChip = hasMicroChip;
            FileId = fileId;
            ProfileImage = profileImage;
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
