namespace Cigirci.Budgeteer.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var name = User?.Identity?.Name;
        var claim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return Ok($"Hello {name} ({claim})");
    }
}
