using HelloPets.Data.Repositories.Interfaces;
using HelloPets.Services.ApplicationServices.Interfaces;
using HelloPets.WebApi.Controllers;
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null && !_passwordService.CompareHashs(request.Password, user.Password, user.Salt.ToByteArray()));
            {
                return Unauthorized("Email or password invalid");
            }

            var token = _tokenService.Generate(user);

            return Ok(new { token });

        }
    }
}
