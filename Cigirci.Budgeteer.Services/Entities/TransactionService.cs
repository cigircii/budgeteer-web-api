namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.Contracts.Requests.Entities.Transaction;
using Cigirci.Budgeteer.DbContext;
using Microsoft.AspNetCore.Http;
using Models.Entities;

public class TransactionService : BudgeteerService<Transaction>
{
    public TransactionService(BudgeteerContext? budgeteerContext = null, IHttpContextAccessor? httpContextAccessor = null) : base(budgeteerContext, httpContextAccessor)
    {
    }

    public async Task<Transaction?> CreateTransaction(CreateTransaction createRequest)
    {
        var transaction = new Transaction
        {
            Name = createRequest.Name,
            Amount = createRequest.Amount,
            Description = createRequest.Description,
            Created = GetCreated(),
            Modified = GetModified(),
            Owner = GetOwner(),
            Status = GetStatus(),
        };

        return await Add(transaction);
    }
}