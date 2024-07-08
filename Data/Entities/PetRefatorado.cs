using HelloPets.Data.Entities;
using System;

namespace Data.Entities
{
    public class PetRefatorado : Entity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string DocumentType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public Guid PublicId { get; private set; }
        public string Nickname { get; private set; }
        public string Furcolor { get; private set; }
        public string Bio { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool Neutered { get; private set; }
        public bool HasMicroChip { get; private set; }
        public int ProfileImageId { get; private set; }
        public string Size { get; private set; }
        public int BredddId { get; private set; }
        public Breed Breed { get; private set; }
        public virtual List<TutorRefatorado> Tutors { get; private set; }
        public virtual List<Trait> Traits { get; private set; }
        public virtual List<Preference> Preferences { get; private set; }
        public virtual List<SprecialNeeds> SprecialNeeds { get; private set; }

        private PetRefatorado() { }

        public PetRefatorado(int id, string name, string document, string documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string nickname, string furcolor, string bio, DateTime? birthdate, bool neutered, bool hasMicroChip, int profileImageId, string size, int bredddId, Breed breed, List<TutorRefatorado> tutors, List<Trait> traits, List<Preference> preferences, List<SprecialNeeds> sprecialNeeds) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId)
        {
            Id = id;
            Name = name;
            Document = document;
            DocumentType = documentType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsActive = isActive;
            PublicId = publicId;
            Nickname = nickname;
            Furcolor = furcolor;
            Bio = bio;
            Birthdate = birthdate;
            Neutered = neutered;
            HasMicroChip = hasMicroChip;
            ProfileImageId = profileImageId;
            Size = size;
            BredddId = bredddId;
            Breed = breed;
            Tutors = tutors;
            Traits = traits;
            Preferences = preferences;
            SprecialNeeds = sprecialNeeds;
        }
    }
}
