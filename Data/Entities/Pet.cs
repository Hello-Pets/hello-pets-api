using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;
public class Pet : Entity
{
    public string Nickname { get; set; }
    public string Furcolor { get; set; }
    public bool Neutered { get; set; }
    public bool HasMicroChip { get; set; }
    public Size Size { get; set; }
    public int BreedId { get; set; }
    public virtual Breed Breed { get; set; }
    public virtual ICollection<Tutor> Tutors { get; set; }
    public virtual ICollection<Trait> Traits { get; set; }
    public virtual ICollection<Preference> Preferences { get; set; }
    public virtual ICollection<SpecialNeeds> SpecialNeeds { get; set; }
    public virtual ICollection<UserPets> UserPets { get; set; }

    public Pet() { }
}