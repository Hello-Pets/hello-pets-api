using HelloPets.Data.Entities;
using HelloPets.Data.Enums;
using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloPets.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : BaseController
{
    private readonly IPasswordService _passwordService;
    private readonly ITutorRepository _tutorRepository;

    public UserController(ITokenService tokenService, IPasswordService passwordService, ITutorRepository tutorRepository) : base(tokenService)
    {
        _passwordService = passwordService;
        _tutorRepository = tutorRepository;
    }

    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody]CreateUserViewModel tutorVM) 
    {
            // Verifica se ja existe usuario com email fornecido e retorna BadRequest caso verdadeiro.
            if(await _tutorRepository.IsRegistered(tutorVM.Email))
                return BadRequest("Email já cadastrado");

            // Verifica se as senhas coincidem.
            if(!tutorVM.Password.Trim().ToLower().Equals(tutorVM.PasswordVerification.Trim().ToLower()))
                return BadRequest("Senhas não coincidem");
    
            // Valida CNPJ caso usuário tenha escolhido tipo Business.
            if(tutorVM.UserType.Equals(UserType.Business)) 
            {
                // Valida se o CNPJ informado tem 14 digitos
                if(tutorVM.Document is null
                    || tutorVM.Document.Length < 14 
                    || tutorVM.Document.Length > 14
                    || tutorVM.Document.Any(ch => char.IsDigit(ch))) 
                        return BadRequest("CNPJ deve conter 14 digitos");
            }

            // Instancia novo TUTOR com base nos dados inseridos no body da request.
            var tutor = new Tutor 
            {
                Name = tutorVM.Name,
                Email = tutorVM.Email.Trim().ToLower(),
                UserType = tutorVM.UserType,
                Document = tutorVM.Document,
            };

            // Faz hash da senha do usuario.
            var hashedPassword = _passwordService.CreateHash(tutorVM.Password + tutor.Salt);
            
            tutor.Password = hashedPassword;
    
            //Salva o novo TUTOR no banco.
            await _tutorRepository.CreateTutorAsync(tutor);
    
            // Retorna view model com os dados necessarios.
            return Ok(new ReturnUserViewModel
            {
                PublicId = tutor.PublicId.ToString().ToLower(),
                Name = tutor.Name,
                Email = tutor.Email,
                UserType = tutor.UserType,
                Token = _tokenService.Generate(tutor)
            }); 
    }

    [HttpPatch("user/{publicId}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateUser([FromRoute]Guid publicId, [FromBody] PatchUserViewModel tutor) {
        // Busca usuario pela PublicId.
        var existingUser = await _tutorRepository.GetTutorByPublicIdAsync(publicId);

        // Retorna BadRequest caso usuário informado nao exista ou esteja inativo.
        if(existingUser is null || !existingUser.IsActive) return BadRequest("Usuário não existe com Id informado.");

        // Verifica se o campo Bio informado é diferente do existente no banco, caso sim altera.
        if(existingUser.Bio != tutor.Bio) 
        {
            existingUser.Bio = tutor.Bio;
            await _tutorRepository.UpdateTutorAsync(existingUser);
        }

        // Verifica se o campo Address informado é diferente do existente no banco, caso sim altera.
        if(existingUser.Address != tutor.Address) 
        {
            existingUser.Address = tutor.Address;
            await _tutorRepository.UpdateTutorAsync(existingUser);
        }

        // Verifica se o campo ProfileImageId informado é diferente do existente no banco, caso sim altera.
        if(existingUser.ProfileImageId != tutor.ProfileImageId) 
        {
            existingUser.ProfileImageId = tutor.ProfileImageId;
            await _tutorRepository.UpdateTutorAsync(existingUser);
        }

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

        // Retorna BadRequest caso usuario ja tenha sido deletado.
        if(!user.IsActive)
            return BadRequest("Usuário já deletado.");

        // Acessa o metodo DeleteTutor do repositorio ja marcando usuario como INATIVO e atualizando o UPDATEAT.
        _tutorRepository.DeleteTutor(user);

        return NoContent();
    }
}