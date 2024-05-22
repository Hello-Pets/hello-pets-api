using Data.ValueObjects;
using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace Data.Entities
{
    internal class Tutor : Entity
    {
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Document Document { get; private set; } = null!;
        public DateTime TutorBirthDate { get; private set; }
        public Address Address { get; private set; } = null!;
        public string TutorPhoto { get; private set; } = null!;
        public MiniBio TutorMiniBio { get; private set; } = null!;
        public PetList PetList { get; private set; } = null!;
        public PhoneNumber PhoneNumber { get; private set; } = null!;
        
        private Tutor() { }

        public Tutor(string firtName, string lastName, string email, int documentTypeEnum, string documentNumber, DateTime tutorBirthDate, string country, string state, string city, string street, string postalCode, string tutorPhoto, string tutorMiniBio/*, List<Pet> petList*/, string countryCode, string localCode, string number)
        {
            Validate(firtName, lastName, email, documentTypeEnum, documentNumber/*, tutorBirthDate*/, country, state, city, street, postalCode, tutorMiniBio, countryCode, localCode, number);

            Name = new Name(firtName, lastName);
            Email = new Email(email);
            Document = new Document(documentTypeEnum, documentNumber);
            TutorBirthDate = new DateTime(tutorBirthDate.Year, tutorBirthDate.Month, tutorBirthDate.Day);
            Address = new Address(country, state, city, street, postalCode);
            TutorPhoto = tutorPhoto;
            TutorMiniBio = new MiniBio(tutorMiniBio);
            //PetList = petList;
            PhoneNumber = new PhoneNumber(countryCode, localCode, number);

        }

        public void Validate(string firtName, string lastName, string email, int documentTypeEnum, string documentNumber/*, DateTime tutorBirthDate*/, string country, string state, string city, string street, string postalCode, string tutorMiniBio,/* List<PetList> petList,*/ string countryCode, string localCode, string number)
        {
            _ = new Name(firtName, lastName);
            _ = new Email(email);
            _ = new Document(documentTypeEnum, documentNumber);
            _ = new Address(country, state, city, street, postalCode);
            _ = new MiniBio(tutorMiniBio);
            _ = new PhoneNumber(countryCode, localCode, number);
        }
    }
}
