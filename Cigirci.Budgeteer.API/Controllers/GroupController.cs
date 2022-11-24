namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Properties;
using Services.Entities;
using Swashbuckle.AspNetCore.Annotations;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class GroupController : ODataController
{
    private readonly GroupService? _groupService;

    public GroupController(GroupService? groupService = null)
    {
        _groupService = groupService;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/groups({id})")]
    [SwaggerOperation("Get group", "Retrieve a specific group", OperationId = "Group.Get")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Group>> GetGroup(Guid id, ODataQueryOptions<Group> query)
    {
        if (_groupService == null) return NotFound();
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/groups")]
    [SwaggerOperation("List groups", "Retrieves a list of groups", OperationId = "Group.List")]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Group>>> GetGroups(ODataQueryOptions<Group> query)
    {
        if (_groupService == null) return NotFound();
        return Ok();
    }
}