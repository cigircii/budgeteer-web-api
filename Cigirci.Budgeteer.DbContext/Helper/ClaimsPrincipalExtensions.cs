namespace Cigirci.Budgeteer.DbContext.Helper;

using System;
using System.Security.Claims;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        var user = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(user);
    }
}