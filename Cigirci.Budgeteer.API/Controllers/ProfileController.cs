namespace Cigirci.Budgeteer.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models.Entities;
using Models.Validation;
using Properties;
using Services.Entities;
using Swashbuckle.AspNetCore.Annotations;

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

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/profiles({id})")]
    [SwaggerOperation("Get profile", "Retrieve a specific profile", OperationId = "Profile.Get")]
    [ProducesResponseType(typeof(Profile), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Profile>> GetProfile(Guid id, ODataQueryOptions<Profile> query)
    {
        if (_profileService == null) return NotFound();
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/profiles")]
    [SwaggerOperation("List profiles", "Retrieves a list of profiles", OperationId = "Profile.List")]
    [ProducesResponseType(typeof(Profile), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles(ODataQueryOptions<Profile> query)
    {
        if (_profileService == null) return NotFound();
        return Ok();
    }
}