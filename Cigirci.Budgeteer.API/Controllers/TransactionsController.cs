namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Enums.Record;
using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Models.Validation;
using Cigirci.Budgeteer.Services;
using Interfaces.Metadata.Record.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class TransactionsController : ODataController
{
    private readonly ILogger<TransactionsController>? _logger;
    private readonly BudgeteerService? _budgeteerService;

    public TransactionsController(ILogger<TransactionsController>? logger = null, BudgeteerService? budgeteerService = null)
    {
        _logger = logger;
        _budgeteerService = budgeteerService;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("List transactions", "Retrieves a list of available transactions", OperationId = "Transaction.List")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(ODataQueryOptions<Transaction> query)
    {
        var transactions = await _budgeteerService.GetAll<Transaction>();
        return Ok(transactions);
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Get transaction", "Retrieve a specific transaction", OperationId = "Transaction.Get")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Transaction>> GetTransaction(Guid id, ODataQueryOptions<Transaction> query)
    {
        //var transaction = await _budgeteerContext.Transactions.FindAsync(id);

        //if (transaction == null)
        //{
        //    return NotFound();
        //}

        //return transaction;

        return Ok();
    }

    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("Create transaction", "Create a transaction", OperationId = "Transaction.Create")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> PostTransaction([FromBody] TransactionRequest transactionRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok();
    }

    //// PUT: api/Transactions/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutTransaction(Guid id, Transaction transaction)
    //{
    //    if (id != transaction.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _budgeteerContext.Entry(transaction).State = EntityState.Modified;

    //    try
    //    {
    //        await _budgeteerContext.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!TransactionExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    //// POST: api/Transactions
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPost]
    //public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    //{
    //    _budgeteerContext.Transactions.Add(transaction);
    //    await _budgeteerContext.SaveChangesAsync();

    //    return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
    //}

    //// DELETE: api/Transactions/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteTransaction(Guid id)
    //{
    //    var transaction = await _budgeteerContext.Transactions.FindAsync(id);
    //    if (transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    _budgeteerContext.Transactions.Remove(transaction);
    //    await _budgeteerContext.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool TransactionExists(Guid id)
    //{
    //    return _budgeteerContext.Transactions.Any(e => e.Id == id);
    //}
}