namespace HelloPets.Data.Entities
{
    public class Breed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpecieId { get; set; }

        public virtual Specie Specie { get; set; }

        public string IsActive { get; set; }
    }
}
