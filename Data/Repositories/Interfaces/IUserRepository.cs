using HelloPets.Data.Entities;

namespace HelloPets.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();

    Task<User> GetUserByIdAsync(int id);

    Task<User> GetUserByPublicIdAsync(Guid publicId);

    Task<bool> IsRegistered(string email);

    Task<User> CreateUserAsync(User user);

    Task<User> UpdateUserAsync(User user);

    Task DeleteUserAsync(User user);
}