using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;

public abstract class Entity
{
    public int? Id {get; set;}
    
    public string? Name { get; set;}
    
    public string? Document { get; set; }
    
    public DocumentType? DocumentType { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public Guid PublicId { get; set; } = Guid.NewGuid();
    
    public string? Bio { get; set; }
    
    public DateTime? Birthdate { get; set; }
    
    public int? FileId { get; set; }
    
    public virtual HelloPetsFile? File { get; set; }
    

    public bool Equals(int id) => Id == id;
    
    public override int GetHashCode() => Id.GetHashCode();
}