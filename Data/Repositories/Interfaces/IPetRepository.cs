using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
using HelloPets.Data.ValueObjects;

namespace HelloPets.Data.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetPetsAsync();
    Task<Pet> GetPetByIdAsync(string id);
    Task<IEnumerable<Pet>> GetPetsByNicknameAsync(string nickName);
    Task<Pet> GetPetByDocumentAsync(string documentNumber);
    Task<IEnumerable<Pet>> GetPetsBySpecieAsync(SpecieEnum specie);
    Task<IEnumerable<Pet>> GetPetsByBreedAsync(string breed);
    Task<IEnumerable<Pet>> GetPetsByNeutered(bool hasBeenNeutered);
    Task<IEnumerable<Pet>> GetPetsByMicrochip(bool hasMicrochip);
    Task<IEnumerable<Pet>> GetPetsBySpecialNeeds(bool hasSpecialNeeds);
    Task<Pet> CreatePetAsync(Pet pet);
    Task<Pet> UpdatePetAsync(Pet pet);
    Task<Pet> DeletePetAsync(Pet pet);
}