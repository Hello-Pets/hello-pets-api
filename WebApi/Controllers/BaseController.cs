using Microsoft.AspNetCore.Mvc;
using Services.ApplicationServices.Interfaces;

namespace HelloPets.WebApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    protected BaseController(ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
    {
        _tokenService = tokenService;
        _httpContextAccessor = httpContextAccessor;
    }
}