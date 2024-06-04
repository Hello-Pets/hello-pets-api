using Data.Entities;
using Data.Exceptions;
using HelloPets.Data.Context;
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

    public async Task<IEnumerable<Tutor>> GetTutorsAsync() => await _context.Tutors.Include(x => x.Pets).AsNoTracking().ToListAsync();

    public async Task<Tutor> GetTutorByIdAsync(string id) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Tutor cannot be found by id - {id}");

    public async Task<IEnumerable<Tutor>> GetTutorsByNameAsync(string firstName, string lastName) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().Where(x => x.Name.FirstName == firstName || x.Name.LastName == lastName).ToListAsync();

    public async Task<Tutor> GetTutorByDocumentAsync(string documentNumber) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().SingleOrDefaultAsync(x => x.Document.Number == documentNumber) ?? throw new DomainExceptionValidation($"Tutor cannot be found by document number - {documentNumber}");

    public async Task<Tutor> GetTutorByEmailAsync(string email) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().SingleOrDefaultAsync(x => x.Email.Address == email) ?? throw new DomainExceptionValidation($"Tutor cannot be found by email - {email}");

    public async Task<IEnumerable<Tutor>> GetTutorsByAddressAsync(string country, string state, string city, string street) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().Where(x => x.Address.Country == country || x.Address.State == state || x.Address.City == city || x.Address.Street == street).ToListAsync();

    public async Task<IEnumerable<Tutor>> GetTutorsByPhoneAsync(string phoneNumber) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().Where(x => x.Phone.Number == phoneNumber).ToListAsync();

    public async Task<IEnumerable<Tutor>> GetTutorsByPostalCodeAsync(string postalCode) => await _context.Tutors.Include(x => x.Pets).AsNoTracking().Where(x => x.Address.PostalCode == postalCode).ToListAsync();

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