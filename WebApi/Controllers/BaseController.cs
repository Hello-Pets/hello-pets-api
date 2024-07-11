using HelloPets.Services.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

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