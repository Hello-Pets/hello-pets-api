using Data.Exceptions;
using HelloPets.Data.ValueObjects;
using System.Text.RegularExpressions;

namespace Data.ValueObjects
{
    internal class Email : ValueObject
    {
        public string Address { get; private set; } = null!;
        //TODO: implantar verification


        private Email() { }

        const string Pattern = @"\w+@\w+\.\w+";

        private static Regex EmailRegex = new Regex(Pattern);

        public Email(string address)
        {
            Address = address;
        }

        private static void Validate(string adress)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(adress.Trim()), "Email cannot be empty");
            DomainExceptionValidation.When(adress.Trim().Length < 5 || adress.Trim().Length > 100,
                "Email must have between 5 and 100 characters");
            DomainExceptionValidation.When(!EmailRegex.IsMatch(adress.Trim()), "Invalid email");
        }

        public static implicit operator Email(string adress) => new Email(adress);

        public static implicit operator string(Email email) => email.ToString();

        public override string ToString() => Address;

    }
}
