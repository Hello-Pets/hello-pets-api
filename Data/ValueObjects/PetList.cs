using HelloPets.Data.Entities;
using HelloPets.Data.ValueObjects;

namespace Data.ValueObjects
{
    internal class PetList : ValueObject//, IEquatable<PetList>
    {
        public List<Pet> Pet { get; private set; } = null!;

        private PetList() { }

        public PetList(List<Pet> pets)
        {
            Pet = pets ?? new List<Pet>();
        }

        //Como usar o ToString aqui
        public override string ToString() => $"";
        //implementar Equals
        public override int GetHashCode() => Pet.GetHashCode();
    }

    
}
