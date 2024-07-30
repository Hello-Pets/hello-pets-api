namespace HelloPets.Data.Entities
{
    public class Preference
    {
        public int Id { get; set; }
        
        public int PetId { get; set; }
        
        public string Value { get; set; }
        
        public bool IsPreference { get; set; }
        
        public bool IsActive { get; set; }
        
        public DateTime DateUpdated { get; set; }
    }
}
