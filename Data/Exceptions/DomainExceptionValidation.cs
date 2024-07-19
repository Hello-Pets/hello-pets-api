namespace HelloPets.Data.Exceptions;
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string message) : base(message) { }

        public static void When(bool message, string errorMessage)
        {
            if (message) throw new DomainExceptionValidation(errorMessage);
        }
    }