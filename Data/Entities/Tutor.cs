using Data.ValueObjects;
using HelloPets.Application.Services.Interfaces;
using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;

namespace Data.Entities
{
    public class Tutor : Entity
    {
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public Document Document { get; private set; } = null!;
        public DateTime? BirthDate { get; private set; }
        public Address Address { get; private set; } = null!;
        public string Photo { get; private set; } = null!;
        public MiniBio MiniBio { get; private set; } = null!;
        public List<Pet> Pets { get; private set; } = new List<Pet>();
        public Phone Phone { get; private set; } = null!;

        private readonly IPasswordService _passwordService;
        
        private Tutor() { }

        public Tutor(string firtName, string lastName, string email, string password, int documentTypeEnum, string documentNumber, DateTime birthDate, string country, string state, string city, string street, string postalCode, string tutorPhoto, string tutorMiniBio, List<Pet> petList , string countryCode, string localCode, string number, IPasswordService passwordService)
        {
            Validate(firtName, lastName, email, password, documentTypeEnum, documentNumber, birthDate, country, state, city, street, postalCode, tutorMiniBio, petList, countryCode, localCode, number, passwordService);

            _passwordService = passwordService;

            Name = new Name(firtName, lastName);
            Email = new Email(email);
            Password = new Password(password, _passwordService);
            Document = new Document(documentTypeEnum, documentNumber);
            BirthDate = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
            Address = new Address(country, state, city, street, postalCode);
            Photo = tutorPhoto;
            MiniBio = new MiniBio(tutorMiniBio);
            Phone = new Phone(countryCode, localCode, number);
        }

        public void Validate(string firtName, string lastName, string email, string password, int documentTypeEnum, string documentNumber, DateTime birthDate, string country, string state, string city, string street, string postalCode, string tutorMiniBio, List<Pet> petList, string countryCode, string localCode, string number, IPasswordService passwordService)
        {
            _ = new Name(firtName, lastName);
            _ = new Email(email);
            _ = new Document(documentTypeEnum, documentNumber);
            if (birthDate < new DateTime(1905, 03, 10)) throw new ArgumentException("Birthdate cannot be inferior than Deolira Gliceira (search for 'Older woman alive')");
            _ = new Address(country, state, city, street, postalCode);
            _ = new MiniBio(tutorMiniBio);
            _ = new Phone(countryCode, localCode, number);
            _ = new Password(password, _passwordService);
        }
    }
}
