namespace HelloPets.Data.Entities
{
    public class Breed
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Specie Specie { get; private set; }
        public string IsActive { get; private set; }
    }
}
