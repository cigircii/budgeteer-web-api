namespace Cigirci.Budgeteer.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Properties;
using Services.Entities;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class ProfileController : ODataController
{
    private readonly ProfileService? _profileService;

    public ProfileController(ProfileService? profileService = null)
    {
        _profileService = profileService;
    }
}