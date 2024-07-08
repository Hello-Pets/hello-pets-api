using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    public class Breed : ValueObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specie Specie { get; set; }
        public string IsActive { get; set; }
    }
}
