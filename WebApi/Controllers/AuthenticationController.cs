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
            //Verifica se email e senha sao nulos
            if (request.Email == null || request.Password == null)
                return BadRequest("Email e senha nao podem estar em branco");

            //Verifica se o email esta registrado
            if (await _userRepository.IsRegistered(request.Email) == false)
                BadRequest("Email ou senha invalido");
            



            //Recupera o Salt do email
            var storedSalt = _userRepository.GetSaltByEmailAsync(request.Email).ToString();

            //Recebe o email digitado
            var inputEmail = await _userRepository.GetUserByEmailAsync(request.Email.ToString());

            //Retorna o Password armazenado
            string storedPassword = await _userRepository.GetPasswordByEmailAsync(request.Email);
            
            //Compara os Passwords
            var validatingPassword = await _passwordService.CompareHashs(request.Password, storedPassword, storedSalt);

            var token = _tokenService.Generate(inputEmail);

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel request)
        {
            if (request == null) return BadRequest("Email nao pode estar em branco");

            var user = await _userRepository.GetUserByEmailAsync(request.Email);




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
