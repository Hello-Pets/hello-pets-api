using HelloPets.Data.Entities;
using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.Controllers;
using HelloPets.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(ITokenService tokenService,
                IPasswordService passwordService,
                IUserRepository userRepository) : base(tokenService)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginViewModel request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == default)
                return BadRequest("Usuario ou senha incorretos");

            if (!_passwordService.ComparePassword
                (request.Password,
                user.Password,
                user.Salt.ToString()))
            {
                return BadRequest("Usuario ou senha incorretos");
            }

            var token = _tokenService.Generate(user, TimeSpan.FromDays(7));

            return Ok(new ReturnUserViewModel()
            {
                PublicId = user.PublicId.ToString(),
                Email = user.Email,
                Name = user.Name,
                UserType = user.UserType,
                Token = token
            });
        }

        [AllowAnonymous]
        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == default)
                return Ok();

            //Implementar API

            var token = _tokenService.Generate(user, TimeSpan.FromMinutes(5));

            return Ok(new { token });
        }


        [Authorize]
        [HttpPost("Update-Password")]
        public async Task<IActionResult> UpdatePassword([FromBody] LoginViewModel request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            user.Salt = Guid.NewGuid();
            user.Password = _passwordService.CreateHash(user.Password + user.Salt);

            var token = _tokenService.Generate(user, TimeSpan.FromDays(7));

            await _userRepository.UpdateUserAsync(user);

            return Ok(new ReturnUserViewModel()
            {
                PublicId = user.PublicId.ToString(),
                Email = user.Email,
                Name = user.Name,
                UserType = user.UserType,
                Token = token
            });
        }
    }
}
