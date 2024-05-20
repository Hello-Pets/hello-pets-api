using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class PhoneNumber : ValueObject
    {
        public string CountryPhoneCode { get; private set; } = "55";
        public string LocalPhoneCode { get; private set; } = null!;
        public string Number { get; private set; } = null!;

        private PhoneNumber() { }

        public PhoneNumber(string countryCode, string localCode, string number)
        {
            Validate(countryCode, localCode, number);
            CountryPhoneCode = countryCode;
            LocalPhoneCode = localCode;
            Number = number;
        }

        public void Validate(string countryCode, string localCode, string number)
        {
            if (countryCode.Any(n => !char.IsDigit(n)) 
                || localCode.Any(n => !char.IsDigit(n)) 
                || number.Any(n => !char.IsDigit(n))) 
                throw new Exception("Only numbers are accepted");


            if (countryCode.Length == 0) throw new NullReferenceException("The country phone code cannot be empty");

            if (localCode.Length == 0) throw new NullReferenceException("The local phone code cannot be empty");

            if (number.Length == 0) throw new NullReferenceException("The Number cannot be empty");

            ValidateStringLength(countryCode, 1, 3);
            ValidateStringLength(localCode, 1, 3);
            ValidateStringLength(number, 7, 10);
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
