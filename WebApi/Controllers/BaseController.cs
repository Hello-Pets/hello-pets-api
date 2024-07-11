using Microsoft.AspNetCore.Mvc;
using Services.ApplicationServices.Interfaces;

namespace HelloPets.WebApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly ITokenService _tokenService;
    protected readonly int _userId;

    protected BaseController(ITokenService tokenService)
    {
        _tokenService = tokenService;
        _userId = _tokenService.GetUserIdFromToken();
    }
}