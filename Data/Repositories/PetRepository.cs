using HelloPets.Data.Context;
using HelloPets.Data.Entities;
using HelloPets.Data.Exceptions;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelloPets.Data.Repositories;

public class PetRepository : IPetRepository
{
    private readonly ApplicationContext _context;

    public PetRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetPetsAsync() => await _context.Pets.Include(x => x.UserPets).AsNoTracking().ToListAsync();
    public async Task<Pet> GetPetByIdAsync(int id) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    public async Task<Pet> GetPetByDocumentAsync(string documentNumber) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().SingleOrDefaultAsync(x => x.Document == documentNumber);
    public async Task<IEnumerable<Pet>> GetPetsByBreedAsync(string breed) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.Breed.Name == breed).ToListAsync();
    public async Task<IEnumerable<Pet>> GetPetsByNicknameAsync(string nickName) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.Nickname == nickName).ToListAsync();
    public async Task<IEnumerable<Pet>> GetPetsBySpecieAsync(string specie) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.Breed.Specie.Name == specie).ToListAsync();
    public async Task<IEnumerable<Pet>> GetPetsByMicrochip(bool hasMicrochip) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.HasMicroChip == hasMicrochip).ToListAsync();
    public async Task<IEnumerable<Pet>> GetPetsByNeutered(bool hasBeenNeutered) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.Neutered == hasBeenNeutered).ToListAsync();
    public async Task<IEnumerable<Pet>> GetPetsBySpecialNeeds(ICollection<SpecialNeeds> hasSpecialNeeds) => await _context.Pets.Include(x => x.UserPets).AsNoTracking().Where(x => x.SpecialNeeds == hasSpecialNeeds).ToListAsync();

    // Melhorar esse metodo.
    public async Task<Pet> CreatePetAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();

        return pet;
    }

    public async Task<Pet> UpdatePetAsync(Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();

        return pet;
    }

    public async Task<Pet> DeletePetAsync(Pet pet)
    {
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();

        return pet;
    }
}