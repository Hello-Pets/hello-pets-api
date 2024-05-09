using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class Birthday : ValueObject, IEquatable<Birthday>
    {
        public DateTime DateOfBirth { get; private set; } = DateTime.Today;

        public Birthday() { }

        public Birthday(DateTime date)
        {

            DateOfBirth = date.Date;
        }

        //TODO: Colocar alguma validacao?

        public override string ToString() => DateOfBirth.ToString("yyyy-MM-dd");

        public override int GetHashCode() => DateOfBirth.GetHashCode();

        public bool Equals(Birthday? birthday) => DateOfBirth == birthday?.DateOfBirth;
    }
}
