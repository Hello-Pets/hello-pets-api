using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloPets.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IPasswordService _passwordService;
    private readonly ITutorRepository _tutorRepository;

    public UserController(ITokenService tokenService, IPasswordService passwordService, ITutorRepository tutorRepository) : base(tokenService)
    {
        _passwordService = passwordService;
        _tutorRepository = tutorRepository;
    }

    [HttpPost("/v1/user")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody]CreateUserViewModel tutor) {
        // Validacoes basicas de email.
        if(!tutor.Email.Equals(tutor.EmailVerification)) throw new ArgumentNullException("Email e verificação de email não coincidem");
        if(string.IsNullOrWhiteSpace(tutor.Email) || string.IsNullOrWhiteSpace(tutor.EmailVerification)) throw new ArgumentException("Email inválido");

        // Verifica se ja existe usuario com email fornecido.
        var existingUser = await _tutorRepository.GetTutorByEmailAsync(tutor.Email);

        // Cria variavel para a senha hasheada.
        string passwordHashed;

        // Lança excecao caso exista usuario com o mesmo email e com o mesmo tipo ativo.
        if(existingUser != null && existingUser.IsActive && existingUser.UserType.Equals(tutor.UserType)) throw new Exception("Email já cadastrado");

        // Caso usuario tenha escolhido o tipo da conta para Business cairá neste fluxo.
        if(tutor.UserType.Equals(UserType.Business)) {
            // Valida se o CNPJ informado tem 14 digitos
            if(tutor.Document?.Length < 0 || tutor.Document?.Length > 14) throw new ArgumentException("CNPJ precisa conter 14 digitos");

            // Faz hash da senha informada.
            passwordHashed = _passwordService.CreateHash(tutor.Password.Trim() + tutor.Salt.ToString());

            // Cria o novo User do tipo business.
            var business = new Tutor(_tokenService.GetUserIdFromToken(), string.Empty, tutor.Document, tutor.Email, DocumentType.CNPJ, DateTime.UtcNow, default, true, Guid.NewGuid(), string.Empty, passwordHashed, tutor.Salt.ToString(), string.Empty, default, string.Empty, string.Empty, default, UserType.Business, new List<UserPets>(), new HelloPetsFile());

            // Salva o novo tutor no banco.
            await _tutorRepository.CreateTutorAsync(business);

            return Ok();
        }

        // Faz hash da senha informada.
        passwordHashed = _passwordService.CreateHash(tutor.Password.Trim() + tutor.Salt.ToString());

        // Cria novo User do tipo Other.
        var newTutor = new Tutor(_tokenService.GetUserIdFromToken(), string.Empty, string.Empty, tutor.Email, DocumentType.Other, DateTime.UtcNow, default, true, Guid.NewGuid(), string.Empty, passwordHashed, tutor.Salt.ToString(), string.Empty, default, string.Empty, string.Empty, default, UserType.Tutor, new List<UserPets>(), new HelloPetsFile());

        //Salva o novo tutor no banco.
        await _tutorRepository.CreateTutorAsync(newTutor);

        return Ok(); 
    }
}