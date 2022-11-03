namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class TestController : ControllerBase
{
    private readonly BudgeteerContext _budgeteerContext;

    public TestController(BudgeteerContext budgeteerContext)
    {
        _budgeteerContext = budgeteerContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var name = User?.Identity?.Name;
        var claim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return Ok($"Hello {name} ({claim})");
    }

    //[AllowAnonymous]
    //[HttpGet("Transaction")]
    //public async Task<IActionResult> GetTransaction()
    //{
    //    {
    //        var transaction = _budgeteerContext?.Transactions?.FirstOrDefault();
    //        return Ok(transaction);
    //    }
    //}
}
