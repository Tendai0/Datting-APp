using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUSers()
    {
        var users = await _context.users.ToListAsync();
        return users;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.users.FindAsync(id);
    }
}
