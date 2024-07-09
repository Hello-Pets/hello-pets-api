﻿using Data.ValueObjects;
using HelloPets.Data.Entities;

namespace Data.Entities
{
    public class Tutor : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string UserType { get; private set; }
        public virtual List<Pet  > Pets { get; private set; }
        public virtual ICollection<UserPets> UserPets { get; private set; }

        private Tutor() { }

        public Tutor(int id, string name, string document, string documentType, DateTime createdAt, DateTime updatedAt, bool isActive, Guid publicId, string username, string password, string salt, string bio, DateTime birthdate, string phone, string address, int profileImageId, string userType, List<Pet> pets, ICollection<UserPets> userPets, HelloPetsFile file) : base(id, name, document, documentType, createdAt, updatedAt, isActive, publicId, bio, birthdate, profileImageId, file)
        {
            Username = username;
            Password = password;
            Salt = salt;
            Phone = phone;
            Address = address;
            UserType = userType;
            Pets = pets;
            UserPets = userPets;
        }
    }
}
