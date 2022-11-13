namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Models.Validation;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
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
    private readonly BudgeteerContext? _budgeteerContext;
    
    public TransactionsController(TransactionService? transactionService = null, ILogger<TransactionsController>? logger = null, BudgeteerContext? budgeteerContext = null)
    {
        _transactionService = transactionService;
        _logger = logger;
        _budgeteerContext = budgeteerContext;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Get transaction", "Retrieve a specific transaction", OperationId = "Transaction.Get")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Transaction>> GetTransaction(Guid id, ODataQueryOptions<Transaction> query)
    {
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("List transactions", "Retrieves a list of available transactions", OperationId = "Transaction.List")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(ODataQueryOptions<Transaction> query)
    {
         //var transactions = await _budgeteerService.GetAll<Transaction>();
        var transactions = await _transactionService?.GetAll();
        //var transactions = await _budgeteerContext?.Transactions?.ToListAsync();
        return new OkObjectResult(transactions);
    }

    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("Create transaction", "Create a transaction", OperationId = "Transaction.Create")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] TransactionRequest transactionRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return CreatedAtAction("CreateTransaction", transactionRequest);
    }

    [EnableQuery]
    [HttpPut(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Update transaction", "Update a transaction", OperationId = "Transaction.Update")]
    [ProducesResponseType(typeof(Transaction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Transaction>> UpdateTransaction([FromBody] TransactionRequest transactionRequest)
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