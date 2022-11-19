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
public class GoalController : ODataController
{
    private readonly GoalService? _goalService;

    public GoalController(GoalService? goalService = null)
    {
        _goalService = goalService;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/goals({id})")]
    [SwaggerOperation("Get goal", "Retrieve a specific goal", OperationId = "Goal.Get")]
    [ProducesResponseType(typeof(Goal), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Goal>> GetGoal(Guid id, ODataQueryOptions<Goal> query)
    {
        if (_goalService == null) return NotFound();
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/goals")]
    [SwaggerOperation("List goals", "Retrieves a list of goals", OperationId = "Goal.List")]
    [ProducesResponseType(typeof(Goal), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Goal>>> GetGoals(ODataQueryOptions<Goal> query)
    {
        if (_goalService == null) return NotFound();
        return Ok();
    }
}