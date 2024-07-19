using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;
public class HelloPetsFile
{
    public int Id { get; private set; }

    public string Name { get; private set; }
    
    public FileType Type { get; private set; }

    public string PublicLink { get; set; }
}