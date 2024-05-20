using Data.Exceptions;
using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class Verification : ValueObject
    {
        public string Code { get; private set; } = Guid.NewGuid().ToString("N")[0..6];
        public DateTime? ExpireAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; }
        public bool IsActive => VerifiedAt == null && ExpireAt > DateTime.UtcNow;

        public Verification() { }

        public void Verify (string code)
        {
            DomainExceptionValidation.When(IsActive, "This code has already been verified");
            DomainExceptionValidation.When(ExpireAt < DateTime.UtcNow, "This code has already expired");
            DomainExceptionValidation.When(string.Equals(Code.Trim(), code.Trim(),
                StringComparison.OrdinalIgnoreCase), "Invalid verificaion code");

            ExpireAt = null;
            VerifiedAt = DateTime.UtcNow;
        }

    }
}
