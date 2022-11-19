namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.Contracts.Requests.Entities.Transaction;
using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class TransactionService : BudgeteerService<Transaction>
{
    public TransactionService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }

    public async Task<Transaction> Create(CreateTransaction createRequest)
    {
        return null;
    }
}