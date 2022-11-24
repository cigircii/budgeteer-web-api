namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.Contracts.Requests.Entities.Transaction;
using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Services.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class TransactionsController : ODataController
{
    private readonly TransactionService? _transactionService;
    private readonly ILogger<TransactionsController>? _logger;

    public TransactionsController(TransactionService? transactionService = null, ILogger<TransactionsController>? logger = null)
    {
        _transactionService = transactionService;
        _logger = logger;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Get transaction", "Retrieve a specific transaction", OperationId = "Transaction.Get")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Transaction?>> GetTransaction(Guid id, ODataQueryOptions<Transaction> query)
    {
        if (_transactionService == null) return NotFound();
        return await _transactionService.Get(id);
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("List transactions", "Retrieves a list of available transactions", OperationId = "Transaction.List")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(ODataQueryOptions<Transaction> query)
    {
        if (_transactionService == null) return NotFound();

        var transactions = await _transactionService?.GetAll();
        return Ok(transactions);
    }

    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("Create transaction", "Create a transaction", OperationId = "Transaction.Create")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] CreateTransaction createRequest)
    {
        if (_transactionService == null) return NotFound();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var transaction = await _transactionService?.CreateTransaction(createRequest);
        return CreatedAtAction("CreateTransaction", transaction);
    }

    [EnableQuery]
    [HttpPut(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Update transaction", "Update a transaction", OperationId = "Transaction.Update")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> UpdateTransaction(Guid id, [FromBody] UpdateTransaction updateRequest)
    {
        if (_transactionService == null) return NotFound();
        
        var properties = updateRequest.GetType().GetProperties();
        var requestIsInvalid = properties.All(property => property.GetValue(updateRequest) == null);
        if (requestIsInvalid) return BadRequest("No properties found to update");

        var transaction = await _transactionService?.UpdateTransaction(id, updateRequest);
        if (transaction == null) return NotFound();

        return Ok(transaction);
    }

    // DELETE: api/Transactions/5
    [HttpDelete(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Delete transaction", "Delete a transaction", OperationId = "Transaction.Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        if (_transactionService == null) return NotFound();

        var transaction = await _transactionService.Get(id);
        if (transaction == null) return NotFound();

        await _transactionService.Delete(id);

        return Ok();
    }
}