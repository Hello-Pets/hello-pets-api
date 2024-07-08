using Data.Enums;

namespace Data.ValueObjects
{
    public class HelloPetsFile
    {
        //Como sera a referencia desta classe em tutor?
        public int Id { get; private set; }
        public string Name { get; private set; }
        //Duvida aqui
        public FileType Type { get; private set; }
        public string PublicLink { get; set; }
    }
}
