using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;

public abstract class Entity
{
    public int? Id {get; set;}
    public string? Name { get; set;}
    public string? Document { get; set; }
    public DocumentType? DocumentType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public Guid PublicId { get; set; }
    public string? Bio { get; set; }
    public DateTime? Birthdate { get; set; }
    public int? ProfileImageId { get; set; }
    public virtual HelloPetsFile? File { get; set; }

    protected Entity() => PublicId = Guid.NewGuid();

    public bool Equals(int id) => Id == id;
    public override int GetHashCode() => Id.GetHashCode();
}