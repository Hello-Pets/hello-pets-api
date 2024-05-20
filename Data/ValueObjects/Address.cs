using HelloPets.Data.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Data.ValueObjects
{
    internal class Address : ValueObject, IEquatable<Address>
    {
        public string Country { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;
        
        private Address() { }

        public Address(string country, string state, string city, string street, string postalCode)
        {
            Validate(country, state, city, street, postalCode);

            Country = country;
            State = state;
            City = city;
            Street = street;
            PostalCode = postalCode;
        }

        public void Validate(string country, string state, string city, string street, string postalCode)
        {
            country = country.Trim();
            state = state.Trim();
            city = city.Trim();
            street = street.Trim();
            postalCode = postalCode.Trim();

            if (country is null || state is null || city is null || street is null || postalCode is null)
                throw new NullReferenceException("The address cannot be empty");

            ValidateStringLength(country, 3, 20);
            ValidateStringLength(state, 3, 20);
            ValidateStringLength(city, 3, 20);
            ValidateStringLength(street, 3, 20);
            ValidateStringLength(postalCode, 3, 20);


        }

        private void ValidateStringLength(string localName, int minLength, int maxLength)
        {
            if (localName.Length < minLength || localName.Length > maxLength)
                throw new ArgumentException($"{localName} must contain between {minLength} and {maxLength} characters");
        }

        public override string ToString() => $"{Country}, {State}, {City}, {Street}, {PostalCode}";

        public override int GetHashCode() => (Country + State + City + Street + PostalCode).GetHashCode();

        public bool Equals(Address? address) => Country == address.Country && State == address.State &&
            Street == address.Street && PostalCode == address.PostalCode;
    }
}
