using Data.Entities;

namespace HelloPets.Data.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetTutorsAsync();
    Task<Tutor> GetTutorByIdAsync(string id);
    Task<IEnumerable<Tutor>> GetTutorsByNameAsync(string firstName, string lastName);
    Task<Tutor> GetTutorByEmailAsync(string email);
    Task<Tutor> GetTutorByDocumentAsync(string documentNumber);
    Task<IEnumerable<Tutor>> GetTutorsByAddressAsync(string country, string state, string city, string street);
    Task<IEnumerable<Tutor>> GetTutorsByPostalCodeAsync(string postalCode);
    Task<IEnumerable<Tutor>> GetTutorsByPhoneAsync(string phoneNumber);
    Task<Tutor> CreateTutorAsync(Tutor tutor);
    Task<Tutor> UpdateTutorAsync(Tutor tutor);
    Task<Tutor> DeleteTutorAsync(Tutor tutor);
}