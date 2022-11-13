namespace Cigirci.Budgeteer.DbContext.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId (this ClaimsPrincipal principal)
    {
        var user = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(user);
    }
}
