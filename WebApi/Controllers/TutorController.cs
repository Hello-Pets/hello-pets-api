using Data.Entities;
using HelloPets.Application.Services.Interfaces;
using HelloPets.Data.Context;
using HelloPets.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelloPets.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IPasswordService _passwordService;
    private readonly ITutorRepository _repo;

    public TutorController(ApplicationContext context, IPasswordService passwordService, ITutorRepository repo)
    {
        _context = context;
        _passwordService = passwordService;
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get() {
        return Ok(await _repo.GetTutorsAsync());
    }

    [HttpPost("accounts/register")]
    public async Task<IActionResult> Register() {
        var tutor = new Tutor("Carlos", "Machado", "carlosmachado@gmail.com", "12345", 0, "12345678912", new DateTime(1999, 12, 1), "Brazil", "Paraná", "Palmas", "ABC Paulista", "85690212", null, "TESTANDO TESTE", null, "55", "46", "988128873", _passwordService);

        return Ok(await _repo.CreateTutorAsync(tutor));
    }
}