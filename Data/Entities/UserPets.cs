namespace HelloPets.Data.Entities
{
    public class UserPets
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public int PetId { get; set; }
        
        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
