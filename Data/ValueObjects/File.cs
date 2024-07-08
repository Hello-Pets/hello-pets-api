namespace Data.ValueObjects
{
    public class File
    {
        //Como sera a referencia desta classe em tutor?
        public int Id { get; private set; }
        public string Name { get; private set; }
        //Duvida aqui
        public FileType Type { get; private set; }
        public string PublicLink { get; set; }
    }
}
