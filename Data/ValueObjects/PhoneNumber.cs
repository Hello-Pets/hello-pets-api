using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class PhoneNumber : ValueObject
    {
        public int CountryPhoneCode { get; private set; } = 55;
        public int LocalPhoneCode { get; private set; }
        public int Number { get; private set; }

        private PhoneNumber() { }

        public PhoneNumber(int countryCode, int localCode, int number)
        {
            Validate(countryCode, localCode, number);
            CountryPhoneCode = countryCode;
            LocalPhoneCode = localCode;
            Number = number;
        }

        public void Validate(int countryCode, int localCode, int number)
        {
            string stringCountryCode = Convert.ToString(countryCode);
            string stringLocalCode = Convert.ToString(localCode);
            string stringNumber = Convert.ToString(number);

            if (stringCountryCode is null) throw new NullReferenceException("The country phone code cannot be empty");

            if (stringLocalCode is null) throw new NullReferenceException("The local phone code cannot be empty");

            if (stringNumber is null) throw new NullReferenceException("The Number cannot be empty");

            ValidateStringLength(stringCountryCode, 1, 3);
            ValidateStringLength(stringLocalCode, 1, 3);
            ValidateStringLength(stringNumber, 7, 10);
        }
        private void ValidateStringLength(string numberToValidate, int minLength, int maxLength)
        {
            if (numberToValidate.Length < minLength || numberToValidate.Length > maxLength)
                throw new ArgumentException($"{numberToValidate} must contain between {minLength} and {maxLength} characters");
        }

        public override string ToString() => $"+{CountryPhoneCode} {LocalPhoneCode} {Number}";

        public override int GetHashCode() => (CountryPhoneCode + LocalPhoneCode + Number).GetHashCode();

        public bool Equals(PhoneNumber? other) => CountryPhoneCode == other?.CountryPhoneCode
            && LocalPhoneCode == other.LocalPhoneCode && Number == other.Number;
    }
}
