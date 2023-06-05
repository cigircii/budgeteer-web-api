namespace Cigirci.Budgeteer.API.Controllers;

using Contracts.Requests.Entities.Subscription;
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
public class SubscriptionController : ODataController
{
    private readonly ILogger<SubscriptionController>? _logger;
    private readonly SubscriptionService? _subscriptionService;

    public SubscriptionController(SubscriptionService? subscriptionService = null,
        ILogger<SubscriptionController>? logger = null)
    {
        _subscriptionService = subscriptionService;
        _logger = logger;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/subscriptions({id})")]
    [SwaggerOperation("Get subscription", "Retrieve a specific subscription", OperationId = "Subscription.Get")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Subscription>> GetSubscription(Guid id, ODataQueryOptions<Subscription> query)
    {
        if (_subscriptionService == null) return NotFound();

        var subscription = await _subscriptionService.Get(id);
        if (subscription is null) return NotFound();

        return Ok(subscription);
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/subscriptions")]
    [SwaggerOperation("List subscriptions", "Retrieves a list of subscriptions", OperationId = "Subscription.List")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions(ODataQueryOptions<Subscription> query)
    {
        if (_subscriptionService == null) return NotFound();

        var subscriptions = await _subscriptionService.GetAll();

        return Ok(subscriptions);
    }

    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/subscriptions")]
    [SwaggerOperation("Create subscription", "Create a subscription", OperationId = "Subscription.Create")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Subscription>> CreateSubscription([FromBody] CreateSubscription createRequest)
    {
        if (_subscriptionService is null) return NotFound();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var subscription = await _subscriptionService.CreateSubscription(createRequest);

        return CreatedAtAction("CreateSubscription", subscription);
    }

    [EnableQuery]
    [HttpPut(ODataProperties.ODataRoutePrefix + "/subscriptions({id})")]
    [SwaggerOperation("Update subscription", "Update a subscription", OperationId = "Subscription.Update")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> UpdateSubscription(Guid id,
        [FromBody] UpdateSubscription updateRequest)
    {
        if (_subscriptionService is null) return NotFound();

        var properties = updateRequest.GetType().GetProperties();
        var requestIsInvalid = properties.All(property => property.GetValue(updateRequest) == null);
        if (requestIsInvalid) return BadRequest("No properties found to update");

        var subscription = await _subscriptionService.UpdateSubscription(id, updateRequest);
        if (subscription == null) return NotFound();

        return Ok(subscription);
    }

    [HttpDelete(ODataProperties.ODataRoutePrefix + "/subscriptions({id})")]
    [SwaggerOperation("Delete subscription", "Delete a subscription", OperationId = "Subscription.Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteSubscription(Guid id)
    {
        if (_subscriptionService == null) return NotFound();

        var subscription = await _subscriptionService.Get(id);
        if (subscription == null) return NotFound();

        await _subscriptionService.Delete(id);

        return Ok();
    }
}