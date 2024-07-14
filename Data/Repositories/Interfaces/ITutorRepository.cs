using HelloPets.Data.Entities;

namespace HelloPets.Data.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetTutorsAsync();
    Task<Tutor> GetTutorByIdAsync(int id);
    Task<Tutor> GetTutorByPublicIdAsync(Guid publicId);
    Task<IEnumerable<Tutor>> GetTutorsByNameAsync(string name);
    Task<Tutor> GetTutorByEmailAsync(string email);
    Task<Tutor> GetTutorByDocumentAsync(string documentNumber);
    Task<IEnumerable<Tutor>> GetTutorsByAddressAsync(string address);
    Task<IEnumerable<Tutor>> GetTutorsByPostalCodeAsync(string postalCode);
    Task<IEnumerable<Tutor>> GetTutorsByPhoneAsync(string phoneNumber);
    Task<Tutor> CreateTutorAsync(Tutor tutor);
    Task<Tutor> UpdateTutorAsync(Tutor tutor);
    Task<Tutor> DeleteTutorAsync(Tutor tutor);
}