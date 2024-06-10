using Data.Exceptions;
using HelloPets.Data.Context;
using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
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

    public async Task<IEnumerable<Pet>> GetPetsAsync() => await _context.Pets.Include(x => x.Tutor).AsNoTracking().ToListAsync();

    public async Task<Pet> GetPetByIdAsync(string id) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Pet cannot be found by id - {id}");

    public async Task<Pet> GetPetByDocumentAsync(string documentNumber) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().SingleOrDefaultAsync(x => x.Document.Number == documentNumber) ?? throw new DomainExceptionValidation($"Pet cannot be found by document number - {documentNumber}");

    public async Task<IEnumerable<Pet>> GetPetsByBreedAsync(string breed) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.Specie.Breed == breed).ToListAsync();

    public async Task<IEnumerable<Pet>> GetPetsByNicknameAsync(string nickName) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.Nickname == nickName).ToListAsync();

    public async Task<IEnumerable<Pet>> GetPetsBySpecieAsync(SpecieEnum specie) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.Specie.PetSpecie == specie).ToListAsync();

    public async Task<IEnumerable<Pet>> GetPetsByMicrochip(bool hasMicrochip) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.HasMicrochip == hasMicrochip).ToListAsync();

    public async Task<IEnumerable<Pet>> GetPetsByNeutered(bool hasBeenNeutered) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.Neutered == hasBeenNeutered).ToListAsync();

    public async Task<IEnumerable<Pet>> GetPetsBySpecialNeeds(bool hasSpecialNeeds) => await _context.Pets.Include(x => x.Tutor).AsNoTracking().Where(x => x.SpecialNeeds == hasSpecialNeeds).ToListAsync();

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