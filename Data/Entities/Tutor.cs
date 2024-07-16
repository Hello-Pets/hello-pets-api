using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;
public class Tutor : Entity
{
    public string? Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; } = Guid.NewGuid().ToString();
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public UserType UserType { get; set; }
    public virtual ICollection<UserPets> UserPets { get; set; }

    public Tutor() { }
}