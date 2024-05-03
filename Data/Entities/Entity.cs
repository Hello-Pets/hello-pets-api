namespace HelloPets.Data.Entities;

public abstract class Entity
{
    public string Id {get; private set;}
    protected Entity() => Id = Guid.NewGuid().ToString()[0..5].ToUpper();

    public bool Equals(string id) => Id == id;
    public override int GetHashCode() => Id.GetHashCode();
}