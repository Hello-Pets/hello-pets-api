using Data.ValueObjects;
using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;

namespace Data.Entities
{
    public class Tutor : Entity
    {
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Document Document { get; private set; } = null!;
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; } = null!;
        public string TutorPhoto { get; private set; } = null!;
        public MiniBio TutorMiniBio { get; private set; } = null!;
        public List<Pet> Pets { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; } = null!;
        
        private Tutor() { }

        public Tutor(string firtName, string lastName, string email, int documentTypeEnum, string documentNumber, DateTime BirthDate, string country, string state, string city, string street, string postalCode, string tutorPhoto, string tutorMiniBio, List<Pet> petList , string countryCode, string localCode, string number)
        {
            Validate(firtName, lastName, email, documentTypeEnum, documentNumber, BirthDate, country, state, city, street, postalCode, tutorMiniBio, petList, countryCode, localCode, number);

            Name = new Name(firtName, lastName);
            Email = new Email(email);
            Document = new Document(documentTypeEnum, documentNumber);
            BirthDate = new DateTime(BirthDate.Year, BirthDate.Month, BirthDate.Day);
            Address = new Address(country, state, city, street, postalCode);
            TutorPhoto = tutorPhoto;
            TutorMiniBio = new MiniBio(tutorMiniBio);
            PhoneNumber = new PhoneNumber(countryCode, localCode, number);
            Pets = new List<Pet>();
        }

        public void Validate(string firtName, string lastName, string email, int documentTypeEnum, string documentNumber, DateTime birthDate, string country, string state, string city, string street, string postalCode, string tutorMiniBio, List<Pet> petList, string countryCode, string localCode, string number)
        {
            _ = new Name(firtName, lastName);
            _ = new Email(email);
            _ = new Document(documentTypeEnum, documentNumber);
            if (birthDate < new DateTime(1905, 03, 10)) throw new ArgumentException("Birthdate cannot be inferior than Deolira Gliceira (search for 'Older woman alive')");
            _ = new Address(country, state, city, street, postalCode);
            _ = new MiniBio(tutorMiniBio);
            _ = new PhoneNumber(countryCode, localCode, number);
        }
    }
}
