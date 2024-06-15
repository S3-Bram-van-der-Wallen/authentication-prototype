using Authentication_prototype_s3.Models;
using Authentication_prototype_s3.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication_prototype_s3.Controllers;

[ApiController]
[Authorize]
public class CountryController : Controller
{
    private readonly UserContext _context;

    public CountryController(UserContext userContext)
    {
        _context = userContext;
    }

    [HttpGet("countries/{id}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Country>>> GetUserCountries(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        var countries = await _context.Countries
            .Where(c => c.UserId == id)
            .Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                UserId = c.UserId,
                User = c.User,
            }).ToListAsync();

        return Ok(countries);
    }
}
