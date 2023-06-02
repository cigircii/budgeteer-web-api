namespace Cigirci.Budgeteer.Services.Entities;

using Contracts.Requests.Entities.Transaction;
using DbContext;
using Models.Entities;

public class TransactionService : BudgeteerService<Transaction>
{
    public TransactionService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }

    public async Task<Transaction?> CreateTransaction(CreateTransaction createRequest)
    {
        var transaction = new Transaction
        {
            Name = createRequest.Name,
            Amount = createRequest.Amount,
            Description = createRequest.Description
        };

        return await Add(transaction);
    }

    public async Task<Transaction?> UpdateTransaction(Guid id, UpdateTransaction updateRequest)
    {
        var transaction = await Get(id);
        if (transaction is null) return null;

        //TODO: Possibly move this to a new location
        if (!string.IsNullOrWhiteSpace(updateRequest.Name)) transaction.Name = updateRequest.Name;

        if (!string.IsNullOrWhiteSpace(updateRequest.Description)) transaction.Description = updateRequest.Description;

        if (updateRequest.Amount.HasValue) transaction.Amount = updateRequest.Amount.Value;

        if (updateRequest.State.HasValue) transaction.Status.State = updateRequest.State.Value;

        return await Update(transaction);
    }
}