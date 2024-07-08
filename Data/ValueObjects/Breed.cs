using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    public class Breed : ValueObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Specie Specie { get; private set; }
        public string IsActive { get; private set; }
    }
}
