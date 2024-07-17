using HelloPets.Data.Context;
using HelloPets.Data.Entities;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HelloPets.Data.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly ApplicationContext _context;

    public TutorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetTutorsAsync() => await _context.Tutors.Include(x => x.UserPets)
        .Where(x => x.IsActive)
        .ToListAsync();

    public async Task<Tutor> GetTutorByIdAsync(int id) => await _context.Tutors.Include(x => x.UserPets)
        .SingleOrDefaultAsync(x => x.Id == id && x.IsActive);

    public async Task<Tutor> GetTutorByPublicIdAsync(Guid publicId) => await _context.Tutors.Include(x => x.UserPets)
        .SingleOrDefaultAsync(x => x.PublicId == publicId && x.IsActive);

    public async Task<Tutor> GetTutorByDocumentAsync(string documentNumber) => await _context.Tutors.SingleOrDefaultAsync(x => x.Document == documentNumber && x.IsActive);

    public async Task<bool> IsRegistered(string email) => await _context.Tutors.AnyAsync(x => x.Email.ToLower() == email.ToLower() && x.IsActive == true);
    // Melhorar esse metodo.
    public async Task<Tutor> CreateTutorAsync(Tutor tutor)
    {
        var newTutor = await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();       
        
        return newTutor.Entity;
    }

    public async Task<Tutor> UpdateTutorAsync(Tutor tutor)
    {
        tutor.UpdatedAt = DateTime.UtcNow;
        var newTutor = _context.Tutors.Update(tutor);
        await _context.SaveChangesAsync();

        return newTutor.Entity;
    }

    public async Task DeleteTutorAsync(Tutor tutor)
    {
        tutor.IsActive = false;
        await UpdateTutorAsync(tutor);
    }
}