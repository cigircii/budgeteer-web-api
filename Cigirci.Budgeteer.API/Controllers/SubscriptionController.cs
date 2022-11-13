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
public class SubscriptionController : ODataController
{
    private readonly SubscriptionService? _subscriptionService;

    public SubscriptionController(SubscriptionService? subscriptionService = null)
    {
        _subscriptionService = subscriptionService;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/subscriptions({id})")]
    [SwaggerOperation("Get subscription", "Retrieve a specific subscription", OperationId = "Subscription.Get")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Subscription>> GetSubscription(Guid id, ODataQueryOptions<Subscription> query)
    {
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/subscriptions")]
    [SwaggerOperation("List subscriptions", "Retrieves a list of subscriptions", OperationId = "Subscription.List")]
    [ProducesResponseType(typeof(Subscription), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions(ODataQueryOptions<Subscription> query)
    {
        return Ok();
    }
}