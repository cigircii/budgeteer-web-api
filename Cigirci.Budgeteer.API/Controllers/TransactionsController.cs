﻿namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Models.Entities;
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
using Interfaces.Metadata.Record.Types;

[Authorize(AuthenticationSchemes = "Bearer")]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class TransactionsController : ODataController
{
    private readonly ILogger<TransactionsController>? _logger;
    private readonly BudgeteerContext? _budgeteerContext;

    public TransactionsController(ILogger<TransactionsController>? logger = null, BudgeteerContext? context = null)
    {
        _logger = logger;
        _budgeteerContext = context;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("List transactions", "Retrieves a list of available transactions", OperationId = "Transaction.List")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(ODataQueryOptions<Transaction> query)
    {
        return await _budgeteerContext.Transactions.ToListAsync();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/transactions({id})")]
    [SwaggerOperation("Get transaction", "Retrieve a specific transaction", OperationId = "Transaction.Get")]
    public async Task<ActionResult<Transaction>> GetTransaction(Guid id, ODataQueryOptions<Transaction> query)
    {
        var transaction = await _budgeteerContext.Transactions.FindAsync(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/transactions")]
    [SwaggerOperation("Create transaction", "Create a transaction", OperationId = "Transaction.Create")]
    public async Task<ActionResult<Transaction>> PostTransaction([FromBody] TransactionRequest transactionRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var transaction = new Transaction
        {
            Name = transactionRequest.Name,
            Description = transactionRequest.Description,
            Amount = transactionRequest.Amount,
            Status = new Status
            {
                Reason = "Submitted",
                State = Enums.Record.State.Active,
            },
            Owner = new Owner
            {
                Id = Guid.NewGuid(),
                Type = 1
            },
            Created = new Created
            {
                By = Guid.NewGuid()
            },
            Modified = new Modified
            {
                By = Guid.NewGuid()
            }
        };
        
        //await _budgeteerContext.Transactions.AddAsync(transaction);
        await _budgeteerContext.AddAsync(transaction);
        await _budgeteerContext.SaveChangesAsync();

        //return CreatedAtAction("Success", new { id = transaction.Id }, transaction);
        return new OkResult();
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