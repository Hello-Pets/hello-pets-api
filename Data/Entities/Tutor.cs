using Data.ValueObjects;
using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;

namespace Data.Entities
{
    internal class Tutor : Entity
    {
        public Name Name { get; } = null!;
        public Email Email { get; } = null!;
        //TODO Implementar atributos faltantes
        
        private Tutor() { }

        public Tutor(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        public static implicit operator string(Tutor tutor) => tutor.ToString();

        public override string ToString()
        {
            return $"{Name} {Email}";
        }
    }
}
