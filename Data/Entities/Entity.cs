namespace HelloPets.Data.Entities;

public abstract class Entity
{
    public string Id {get; private set;}
    public string Name { get; private set;}
    public string Document { get; private set; }
    public string DocumentType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool IsActive { get; private set; }
    public Guid PublicId { get; private set; }
    public string Bio { get; private set; }
    public DateTime Birthdate { get; private set; }
    public int ProfileImageId { get; private set; }
    protected Entity() => Id = Guid.NewGuid().ToString()[0..5].ToUpper();

    public bool Equals(string id) => Id == id;
    public override int GetHashCode() => Id.GetHashCode();
}