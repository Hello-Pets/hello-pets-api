using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.Controllers;
using HelloPets.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> RequestToken([FromBody] LoginViewModel request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null || !_passwordService.ComparePassword(request.Password, user.Password, user.Salt))
            {
                return Unauthorized("Email ou senha invalido");
            }

            var token = _tokenService.Generate(user);

            return Ok(new { token });
        }

        [AllowAnonymous]
        [HttpPost("Forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null) return BadRequest("Email nao pode estar em branco");




            return Ok();
        }


        [Authorize]
        [HttpPost("Update Password")]
        public async Task<IActionResult> UpdatePassword([FromBody] LoginViewModel request)
        {



            return Ok();
        }
    }
}
