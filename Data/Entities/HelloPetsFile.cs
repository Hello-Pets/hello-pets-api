using HelloPets.Data.Enums;

namespace HelloPets.Data.Entities;

public class HelloPetsFile
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public FileType Type { get; set; }

    public string PublicLink { get; set; }
}