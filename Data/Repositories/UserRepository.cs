using HelloPets.Data.Context;
using HelloPets.Data.Entities;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelloPets.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync() => 
        await _context.Tutors.Where(x => x.IsActive)
            .ToListAsync();

    public async Task<User> GetUserByIdAsync(int id) => 
        await _context.Tutors.SingleOrDefaultAsync(x => x.Id == id 
            && x.IsActive);

    public async Task<User> GetUserByPublicIdAsync(Guid publicId) => 
        await _context.Tutors.SingleOrDefaultAsync(x => x.PublicId == publicId 
            && x.IsActive);

    public async Task<bool> IsRegistered(string email) => 
        await _context.Tutors.AnyAsync(x => x.Email.ToLower() == email.ToLower() 
            && x.IsActive == true);

    public async Task<User> CreateUserAsync(User tutor)
    {
        var newTutor = await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();       
        
        return newTutor.Entity;
    }

    public async Task<User> UpdateUserAsync(User tutor)
    {
        tutor.UpdatedAt = DateTime.UtcNow;
        var newTutor = _context.Tutors.Update(tutor);
        await _context.SaveChangesAsync();

        return newTutor.Entity;
    }

    public async Task DeleteUserAsync(User tutor)
    {
        tutor.IsActive = false;
        await UpdateUserAsync(tutor);
    }
}