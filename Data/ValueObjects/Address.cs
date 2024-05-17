using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class Address : ValueObject, IEquatable<Address>
    {
        public string Country { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;
        
        private Address() { }

        public Address (string street, string city, string state, string postalCode)
        {
            Validate(street, city, state, postalCode);

            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }


        //TODO: Melhorar validacao
        public void Validate(string street, string city, string state, string postalCode)
        {
            street = street.Trim();
            city = city.Trim();
            state = state.Trim();
            postalCode = postalCode.Trim();

            if (street is null || city is null || state is null || postalCode is null)
                throw new NullReferenceException("Street cannot be empty");

            if (city.Length < 3 || city.Length > 20)
                throw new ArgumentException("City must contain between 3 and 20 characters");
            
            if (state.Length < 3 || state.Length > 20)
                throw new ArgumentException("Street must contain between 3 and 20 characters");

            if (postalCode.Length < 3 || postalCode.Length > 20)
                throw new ArgumentException("Postal Code must contain between 3 and 20 characters");


        }

        //Duvida: Precisa de ToString aqui?
        //public override string ToString() => $"";

        public override int GetHashCode() => (Street + City + State + PostalCode).GetHashCode();

        public bool Equals(Address? address) => Street == address?.Street && City == address.City &&
            State == address.State && PostalCode == address.PostalCode;
    }
}
