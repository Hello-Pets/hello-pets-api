using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloPets.WebApi.Controllers;

[Route("api/v1/[controller]")]
public class UserController : BaseController
{
    private readonly IPasswordService _passwordService;
    private readonly ITutorRepository _tutorRepository;

    public UserController(ITokenService tokenService,
    IPasswordService passwordService, 
    ITutorRepository tutorRepository) : base(tokenService)
    {
        _passwordService = passwordService;
        _tutorRepository = tutorRepository;
    }

    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody]CreateUserViewModel userVM) 
    {
            // Verifica se ja existe usuario com email fornecido e retorna BadRequest caso verdadeiro.
            if(await _tutorRepository.IsRegistered(userVM.Email))
                return BadRequest("Email já cadastrado");

            // Verifica se as senhas coincidem.
            if(!userVM.Password.Trim().Equals(userVM.PasswordVerification.Trim()))
                return BadRequest("Senhas não coincidem");
    
            // Valida CNPJ caso usuário tenha escolhido tipo Business.
            if(userVM.UserType.Equals(UserType.Business)) 
            {
                // Valida se o CNPJ informado tem 14 digitos.
                if(userVM.DocumentType == DocumentType.CNPJ && userVM.Document?.Length != 14 && userVM.Document.Any(ch => char.IsDigit(ch)))
                    return BadRequest("CNPJ deve conter 14 digitos");
            }

            // Instancia novo TUTOR com base nos dados inseridos no body da request.
            var user = new Tutor 
            {
                Name = userVM.Name,
                Email = userVM.Email.Trim().ToLower(),
                UserType = userVM.UserType,
                Document = userVM.Document,
                Password = _passwordService.CreateHash(userVM.Password + userVM.Salt),
                Salt = userVM.Salt.ToString(),
            };
    
            //Salva o novo TUTOR no banco.
            await _tutorRepository.CreateTutorAsync(user);
    
            // Retorna view model com os dados necessarios.
            return Ok(new ReturnUserViewModel
            {
                PublicId = user.PublicId.ToString().ToLower(),
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType,
                Token = _tokenService.Generate(user)
            }); 
    }

    [HttpPatch("user/{publicId}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateUser([FromRoute]Guid publicId, [FromBody] PatchUserViewModel user) {
        // Busca usuario pela PublicId.
        var existingUser = await _tutorRepository.GetTutorByPublicIdAsync(publicId);

        // Retorna BadRequest caso usuário informado nao exista ou esteja inativo.
        if(existingUser is null) return BadRequest("Usuário não existe com Id informado.");

        if(existingUser.Id != user.Id)
            return BadRequest("ID do usuário diferente do fornecido");

        // Verifica se o campo Bio informado é diferente do existente no banco, caso sim altera.
        if(existingUser.Bio != user.Bio)
            existingUser.Bio = user.Bio;

        // Verifica se o campo Address informado é diferente do existente no banco, caso sim altera.
        if(existingUser.Address != user.Address) 
            existingUser.Address = user.Address;

        // Verifica se o campo ProfileImageId informado é diferente do existente no banco, caso sim altera.
        if(existingUser.ProfileImageId != user.ProfileImageId) 
            existingUser.ProfileImageId = user.ProfileImageId;

        await _tutorRepository.UpdateTutorAsync(existingUser);

        return NoContent();
    }

    [HttpDelete("user/{publicId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid publicId, [FromBody] DeleteUserViewModel userVM) 
    {
        // Busca usuario pelo PublicId informado.
        var user = await _tutorRepository.GetTutorByPublicIdAsync(publicId);

        // Retorna BadRequest caso usuario não exista na base de dados.
        if(user is null)
            return BadRequest("Usuário não existente.");

        // Retorna BadRequest caso ID seja diferente do fornecido pelo usuario no body.
        if(user.Id != userVM.Id)
            return BadRequest("ID do usuário diferente do fornecido.");

        // Acessa o metodo DeleteTutor do repositorio ja marcando usuario como INATIVO e atualizando o UPDATEAT.
        await _tutorRepository.DeleteTutorAsync(user);

        return NoContent();
    }
}