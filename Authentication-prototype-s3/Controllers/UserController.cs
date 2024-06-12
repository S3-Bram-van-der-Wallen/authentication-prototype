using Authentication_prototype_s3.Models;
using Authentication_prototype_s3.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_prototype_s3.Controllers;

[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly UserContext _context;

    public UserController(UserContext userContext)
    {
        _context = userContext;
    }

    [HttpGet("users/{id}")]
    public async Task<ActionResult<IEnumerable<User>>> GetUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        return Ok(user);
    }
}
