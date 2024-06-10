using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    public class Phone : ValueObject
    {
        public string CountryPhoneCode { get; private set; } = null!;
        public string LocalPhoneCode { get; private set; } = null!;
        public string Number { get; private set; } = null!;

        private Phone() { }

        public Phone(string countryCode = "", string localCode = "", string number = "")
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

        public bool Equals(Phone? other) => CountryPhoneCode == other?.CountryPhoneCode
            && LocalPhoneCode == other.LocalPhoneCode && Number == other.Number;
    }
}
