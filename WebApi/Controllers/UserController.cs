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
    private readonly IUserRepository _tutorRepository;

    public UserController(ITokenService tokenService,
    IPasswordService passwordService, 
    IUserRepository tutorRepository) : base(tokenService)
    {
        _passwordService = passwordService;
        _tutorRepository = tutorRepository;
    }

    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody]CreateUserViewModel userVM) 
    {
            if(await _tutorRepository.IsRegistered(userVM.Email))
                return BadRequest("Email já cadastrado");

            if(!userVM.Password.Trim().Equals(userVM.PasswordVerification.Trim()))
                return BadRequest("Senhas não coincidem");
    
            if(userVM.UserType == UserType.Business) 
            {
                if(userVM.DocumentType != DocumentType.CNPJ &&
                    userVM.Document is not null &&
                    userVM.Document?.Length != 14 && 
                    userVM.Document.Any(ch => char.IsDigit(ch)))
                        return BadRequest("CNPJ inválido");
            }

            var user = new User 
            {
                Name = userVM.Name,
                Email = userVM.Email.Trim().ToLower(),
                UserType = userVM.UserType,
                Document = userVM.Document,
                Password = _passwordService.CreateHash(userVM.Password + userVM.Salt),
                Salt = userVM.Salt.ToString(),
            };
    
            await _tutorRepository.CreateUserAsync(user);
    
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
    public async Task<IActionResult> UpdateUser([FromRoute]Guid publicId, [FromBody] PatchUserViewModel user) 
    {
        var existingUser = await _tutorRepository.GetUserByPublicIdAsync(publicId);

        if(existingUser is null) 
            return BadRequest("Usuário não existe com Id informado.");

        if(existingUser.Id != user.Id)
            return BadRequest("ID do usuário diferente do fornecido");

        if(existingUser.Bio != user.Bio)
            existingUser.Bio = user.Bio;

        if(existingUser.Address != user.Address) 
            existingUser.Address = user.Address;

        if(existingUser.ProfileImageId != user.ProfileImageId) 
            existingUser.ProfileImageId = user.ProfileImageId;

        await _tutorRepository.UpdateUserAsync(existingUser);

        return NoContent();
    }

    [HttpDelete("user/{publicId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid publicId, [FromBody] DeleteUserViewModel userVM) 
    {
        var user = await _tutorRepository.GetUserByPublicIdAsync(publicId);

        if(user is null)
            return BadRequest("Usuário não existente.");

        if(user.Id != userVM.Id)
            return BadRequest("ID do usuário diferente do fornecido.");

        await _tutorRepository.DeleteUserAsync(user);

        return NoContent();
    }
}