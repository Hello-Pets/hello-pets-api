using HelloPets.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace HelloPets.Data.Entities;

public class User : Entity
{
    public string? Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public Guid Salt { get; set; } = Guid.NewGuid();
    
    public string? Phone { get; set; }
    
    public string? Address { get; set; }
    
    public UserType UserType { get; set; }
    
    public virtual ICollection<UserPets> UserPets { get; set; }
}