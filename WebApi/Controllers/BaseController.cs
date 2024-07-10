using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloPets.WebApi.Controllers;

[ApiController]
[Authorize("")]
public abstract class BaseController : ControllerBase
{
    
}