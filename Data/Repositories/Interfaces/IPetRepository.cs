using HelloPets.Data.Entities;

namespace HelloPets.Data.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetPetsAsync();
    Task<Pet> GetPetByIdAsync(int id);
    Task<Pet> GetPetByDocumentAsync(string documentNumber);
    Task<IEnumerable<Pet>> GetPetsBySpecieAsync(string specie);
    Task<IEnumerable<Pet>> GetPetsByBreedAsync(string breed);
    Task<IEnumerable<Pet>> GetPetsByNeutered(bool hasBeenNeutered);
    Task<IEnumerable<Pet>> GetPetsByMicrochip(bool hasMicrochip);
    Task<IEnumerable<Pet>> GetPetsBySpecialNeeds(ICollection<SpecialNeeds> hasSpecialNeeds);
    Task<Pet> CreatePetAsync(Pet pet);
    Task<Pet> UpdatePetAsync(Pet pet);
    Task<Pet> DeletePetAsync(Pet pet);
}