using Data.Exceptions;
using HelloPets.Data.ValueObjects;
using System.Text.RegularExpressions;

namespace Data.ValueObjects
{
    internal class Email : ValueObject
    {
        public string Address { get; private set; } = null!;
        public Verification Verification { get; private set; } = new Verification();

        const string Pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

        private static readonly Regex EmailRegex = new Regex(Pattern);

        private Email() { }

        public Email(string address)
        {
            Validate(address);
            Address = address;
        }

        private static void Validate(string address)
        {
            string trimmedAddress = address.Trim();

            DomainExceptionValidation.When(string.IsNullOrEmpty(trimmedAddress), "Email cannot be empty");
            DomainExceptionValidation.When(trimmedAddress.Length < 5 || trimmedAddress.Length > 100,
                "Email must have between 5 and 100 characters");
            DomainExceptionValidation.When(!EmailRegex.IsMatch(trimmedAddress), "Invalid email");
        }

        public static implicit operator Email(string address) => new Email(address);

        public static implicit operator string(Email email) => email.ToString();

        public override string ToString() => Address;

        public void ResendVerificationCode() => Verification = new Verification();
    }
}
