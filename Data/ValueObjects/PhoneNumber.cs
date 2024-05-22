using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class PhoneNumber : ValueObject
    {
        public string CountryPhoneCode { get; private set; } = "55";
        public string LocalPhoneCode { get; private set; } = "00";
        public string Number { get; private set; } = "000000000";

        private PhoneNumber() { }

        public PhoneNumber(string countryCode, string localCode, string number)
        {
            if (countryCode != "55" || localCode != "00" || number != "000000000")
            {
                Validate(countryCode, localCode, number);
            }
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
