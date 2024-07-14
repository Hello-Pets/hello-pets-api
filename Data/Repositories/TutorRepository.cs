using HelloPets.Data.Context;
using HelloPets.Data.Entities;
using HelloPets.Data.Exceptions;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelloPets.Data.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly ApplicationContext _context;

    public TutorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetTutorsAsync() => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().ToListAsync();
    public async Task<Tutor> GetTutorByIdAsync(int id) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<Tutor>> GetTutorsByNameAsync(string name) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().Where(x => x.Name == name).ToListAsync();
    public async Task<Tutor> GetTutorByDocumentAsync(string documentNumber) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().SingleOrDefaultAsync(x => x.Document == documentNumber);
    public async Task<Tutor> GetTutorByEmailAsync(string email) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().SingleOrDefaultAsync(x => x.Email == email);
    public async Task<IEnumerable<Tutor>> GetTutorsByAddressAsync(string address) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().Where(x => x.Address == address).ToListAsync();
    public async Task<IEnumerable<Tutor>> GetTutorsByPhoneAsync(string phoneNumber) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().Where(x => x.Phone == phoneNumber).ToListAsync();
    public async Task<IEnumerable<Tutor>> GetTutorsByPostalCodeAsync(string postalCode) => await _context.Tutors.Include(x => x.UserPets).AsNoTracking().Where(x => x.Address == postalCode).ToListAsync();
    // Melhorar esse metodo.
    public async Task<Tutor> CreateTutorAsync(Tutor tutor)
    {
        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();

        return tutor;
    }

    public async Task<Tutor> UpdateTutorAsync(Tutor tutor)
    {
        _context.Tutors.Update(tutor);
        await _context.SaveChangesAsync();

        return tutor;
    }

    public async Task<Tutor> DeleteTutorAsync(Tutor tutor)
    {
        _context.Tutors.Remove(tutor);
        await _context.SaveChangesAsync();

        return tutor;
    }

}