using Data.Enums;

namespace HelloPets.Data.Entities
{
    public class Tutor : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Salt { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public UserType UserType { get; private set; }
        public virtual ICollection<UserPets> UserPets { get; private set; }

        private Tutor() { }

        public Tutor(int id, string name, string document,string email, DocumentType documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string username, string password, string salt, string bio, DateTime birthdate, string phone, string address, int profileImageId, UserType userType, ICollection<UserPets> userPets, HelloPetsFile file) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId, file)
        {
            Username = username;
            Password = password;
            Email = email;
            Salt = salt;
            Phone = phone;
            Address = address;
            UserType = userType;
            UserPets = userPets;
        }
    }
}
