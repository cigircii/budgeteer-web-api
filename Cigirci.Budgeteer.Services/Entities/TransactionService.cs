namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class TransactionService : BudgeteerService<Transaction>
{
    public TransactionService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}