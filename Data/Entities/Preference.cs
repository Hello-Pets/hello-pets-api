namespace HelloPets.Data.Entities
{
    public class Preference
    {
        public int Id { get; private set; }
        
        public int PetId { get; private set; }
        
        public string Value { get; private set; }
        
        public bool IsPreference { get; private set; }
        
        public bool IsActive { get; private set; }
        
        public DateTime DateUpdated { get; private set; }
    }
}
