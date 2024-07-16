using HelloPets.Data.Entities;

namespace HelloPets.Data.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetTutorsAsync();

    Task<Tutor> GetTutorByIdAsync(int id);

    Task<Tutor> GetTutorByPublicIdAsync(Guid publicId);

    Task<bool> IsRegistered(string email);

    Task<Tutor> GetTutorByDocumentAsync(string documentNumber);

    Task<Tutor> CreateTutorAsync(Tutor tutor);

    Task<Tutor> UpdateTutorAsync(Tutor tutor);

    Task DeleteTutorAsync(Tutor tutor);
}