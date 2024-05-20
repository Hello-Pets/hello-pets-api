using Data.ValueObjects;
using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;

namespace Data.Entities
{
    internal class Tutor : Entity
    {
        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Document Document { get; private set; } = null!;
        public DateTime TutorBirthDate { get; private set; }
        //implementar Senha
        public Address Address { get; private set; } = null!;
        //Conferir infos sobre foto
        public string TutorPhoto { get; private set; } = null!;
        public MiniBio TutorMiniBio { get; private set; } = null!;
        public PetList PetList { get; private set; } = null!;
        public PhoneNumber PhoneNumber { get; private set; } = null!;
        
        private Tutor() { }

        public Tutor(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        //public static implicit operator string(Tutor tutor) => tutor.ToString();

        //public override string ToString()
        //{
        //    return $"{Name} {Email}";
        //}

        //implementar Validate

        //Implementar Update
    }
}
