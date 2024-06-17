using Authentication_prototype_s3.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Authentication_prototype_s3.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(UserContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult GetData()
    {
        return Ok("Secure data");
    }
}
