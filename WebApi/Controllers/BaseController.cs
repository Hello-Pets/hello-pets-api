using Microsoft.AspNetCore.Mvc;
using Services.ApplicationServices.Interfaces;

namespace HelloPets.WebApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly int _userId;

    protected BaseController(ITokenService tokenService)
    {
        _tokenService = tokenService;
        _userId = _tokenService.GetUserIdFromToken();
    }
}