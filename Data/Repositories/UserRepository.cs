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
        await _context.Users.Where(x => x.IsActive)
            .ToListAsync();

    public async Task<User> GetUserByIdAsync(int id) =>
        await _context.Users.FirstOrDefaultAsync(x => x.Id == id
            && x.IsActive);

    public async Task<User> GetUserByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(x => x.Email == email
            && x.IsActive);

    public async Task<User> GetUserByPublicIdAsync(Guid publicId) =>
        await _context.Users.FirstOrDefaultAsync(x => x.PublicId == publicId
            && x.IsActive);

    public async Task<bool> IsRegistered(string email) =>
        await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower() && x.IsActive);

    public async Task<User> CreateUserAsync(User user)
    {
        var newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return newUser.Entity;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        var newUser = _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return newUser.Entity;
    }

    public async Task DeleteUserAsync(User user)
    {
        user.IsActive = false;
        await UpdateUserAsync(user);
    }
}