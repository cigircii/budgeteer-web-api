namespace Cigirci.Budgeteer.API.Controllers;

using Contracts.Requests.Entities.Goal;
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
public class GoalController : ODataController
{
    private readonly ILogger<GoalController>? _logger;
    private readonly GoalService? _goalService;

    public GoalController(ILogger<GoalController>? logger = null
        , GoalService? goalService = null)
    {
        _goalService = goalService;
        _logger = logger;
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

        var goal = await _goalService.Get(id);
        if (goal is null) return NotFound();
        
        return Ok(goal);
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/goals")]
    [SwaggerOperation("List goals", "Retrieves a list of goals", OperationId = "Goal.List")]
    [ProducesResponseType(typeof(Goal), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Goal>>> GetGoals(ODataQueryOptions<Goal> query)
    {
        if (_goalService == null) return NotFound();

        var goals = await _goalService.GetAll();
        
        return Ok(goals);
    }
    
    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/goals")]
    [SwaggerOperation("Create goal", "Create a goal", OperationId = "Goal.Create")]
    [ProducesResponseType(typeof(Goal), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Goal>> CreateGoal([FromBody] CreateGoal createRequest)
    {
        if (_goalService is null) return NotFound();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var goal = await _goalService.CreateGoal(createRequest);
        return CreatedAtAction("CreateGoal", goal);
    }
    
    [EnableQuery]
    [HttpPut(ODataProperties.ODataRoutePrefix + "/goals({id})")]
    [SwaggerOperation("Update goal", "Update a goal", OperationId = "Goal.Update")]
    [ProducesResponseType(typeof(Goal), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Goal>> UpdateGoal(Guid id, [FromBody] UpdateGoal updateRequest)
    {
        if (_goalService is null) return NotFound();

        var properties = updateRequest.GetType().GetProperties();
        var requestIsInvalid = properties.All(property => property.GetValue(updateRequest) == null);
        
        if (requestIsInvalid) return BadRequest("No properties found to update");

        var goal = await _goalService.UpdateGoal(id, updateRequest);
        if (goal == null) return NotFound();

        return Ok(goal);
    }
}