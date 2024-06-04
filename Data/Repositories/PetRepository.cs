using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
using HelloPets.Data.Repositories.Interfaces;

namespace HelloPets.Data.Repositories;

public class PetRepository : IPetRepository
{
    public Task<Pet> CreatePetAsync(Pet pet)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> DeletePetAsync(Pet pet)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> GetPetByDocumentAsync(string documentNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> GetPetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsByBreedAsync(string breed)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsByMicrochip(bool hasMicrochip)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsByNeutered(bool hasBeenNeutered)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsByNicknameAsync(string nickName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsBySpecialNeeds(bool hasSpecialNeeds)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> GetPetsBySpecieAsync(SpecieEnum specie)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> UpdatePetAsync(Pet pet)
    {
        throw new NotImplementedException();
    }
}