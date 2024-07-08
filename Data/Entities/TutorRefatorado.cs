using HelloPets.Data.Entities;

namespace Data.Entities
{
    public class TutorRefatorado : Entity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string DocumentType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public Guid PublicId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Bio { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public int ProfileImageId { get; private set; }
        public string UserType { get; private set; }
        public virtual List<PetRefatorado  > Pets { get; private set; }

        private TutorRefatorado() { }

        public TutorRefatorado(int id, string name, string document, string documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string username, string password, string salt, string bio, DateTime birthdate, string phone, string address, int profileImageId, string userType) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId)
        {
            Id = id;
            Name = name;
            Document = document;
            DocumentType = documentType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsActive = isActive;
            PublicId = publicId;
            Username = username;
            Password = password;
            Salt = salt;
            Bio = bio;
            Birthdate = birthdate;
            Phone = phone;
            Address = address;
            ProfileImageId = profileImageId;
            UserType = userType;
        }
    }
}
