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
            if(!tutor.Email.Equals(tutor.EmailVerification)) return BadRequest("Email e verificação de email não coincidem");
            if(string.IsNullOrWhiteSpace(tutor.Email) || string.IsNullOrWhiteSpace(tutor.EmailVerification)) BadRequest("Email inválido");
    
            // Verifica se ja existe usuario com email fornecido.
            var existingUser = await _tutorRepository.GetTutorByEmailAsync(tutor.Email);
    
            // Cria variavel para a senha hasheada.
            string passwordHashed;
    
            // Lança excecao caso exista usuario com o mesmo email e com o mesmo tipo ativo.
            if(existingUser != null && existingUser.IsActive && existingUser.UserType.Equals(tutor.UserType)) BadRequest("Email já cadastrado");
    
            // Caso usuario tenha escolhido o tipo da conta para Business cairá neste fluxo.
            if(tutor.UserType.Equals(UserType.Business)) {
                // Valida se o CNPJ informado tem 14 digitos
                if(tutor.Document is null || tutor.Document.Length < 14 || tutor.Document.Length > 14) return BadRequest("CNPJ precisa conter 14 digitos");
    
                // Faz hash da senha informada.
                passwordHashed = _passwordService.CreateHash(tutor.Password.Trim() + tutor.Salt.ToString());
    
                // Cria o novo User do tipo business.
                var business = new Tutor{
                    Email = tutor.Email, 
                    Document = tutor.Document,
                    DocumentType =DocumentType.CNPJ, 
                    CreatedAt = DateTime.UtcNow, 
                    IsActive = true, 
                    PublicId = Guid.NewGuid(),
                    Password = passwordHashed, 
                    Salt = tutor.Salt.ToString(),
                    UserType = UserType.Business
                };

                // Salva o novo tutor no banco.
                await _tutorRepository.CreateTutorAsync(business);
    
                return Ok();
            }
    
            // Faz hash da senha informada.
            passwordHashed = _passwordService.CreateHash(tutor.Password.Trim() + tutor.Salt.ToString());
    
            // Cria novo User do tipo Other.
            var newTutor = new Tutor{
                Email = tutor.Email, 
                DocumentType =DocumentType.Other, 
                CreatedAt = DateTime.UtcNow, 
                IsActive = true, 
                PublicId = Guid.NewGuid(),
                Password = passwordHashed, 
                Salt = tutor.Salt.ToString(),
                UserType = UserType.Tutor
            };

    
            //Salva o novo tutor no banco.
            await _tutorRepository.CreateTutorAsync(newTutor);
    
            return Ok(); 
    }
}