using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    public class Address : ValueObject, IEquatable<Address>
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }

        public static Address Empty => new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

        private Address()
        {
            Country = string.Empty;
            State = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            PostalCode = string.Empty;
        }

        public Address(string country, string state, string city, string street, string postalCode)
        {
            Validate(country, state, city, street, postalCode);

            Country = country ?? string.Empty;
            State = state ?? string.Empty;
            City = city ?? string.Empty;
            Street = street ?? string.Empty;
            PostalCode = postalCode ?? string.Empty;
        }

        public void Validate(string? country, string? state, string? city, string? street, string? postalCode)
        {
            if (country != null) country = country.Trim();
            if (state != null) state = state.Trim();
            if (city != null) city = city.Trim();
            if (street != null) street = street.Trim();
            if (postalCode != null) postalCode = postalCode.Trim();

            if (!string.IsNullOrEmpty(country)) ValidateStringLength(country, 3, 20);
            if (!string.IsNullOrEmpty(state)) ValidateStringLength(state, 3, 20);
            if (!string.IsNullOrEmpty(city)) ValidateStringLength(city, 3, 20);
            if (!string.IsNullOrEmpty(street)) ValidateStringLength(street, 3, 20);
            if (!string.IsNullOrEmpty(postalCode)) ValidateStringLength(postalCode, 3, 20);

        }

        private void ValidateStringLength(string localName, int minLength, int maxLength)
        {
            if (localName.Length < minLength || localName.Length > maxLength)
                throw new ArgumentException($"{localName} must contain between {minLength} and {maxLength} characters");
        }

        public override string ToString() => $"{Country}, {State}, {City}, {Street}, {PostalCode}";

        public override int GetHashCode() => (Country + State + City + Street + PostalCode).GetHashCode();

        public bool Equals(Address? address)
        {
            if (address is null) return false;

            return Country == address.Country &&
                State == address.State &&
                City == address.City &&
                Street == address.Street &&
                PostalCode == address.PostalCode;
        }
    }
}
