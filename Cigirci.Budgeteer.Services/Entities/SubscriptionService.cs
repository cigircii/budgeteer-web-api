namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class SubscriptionService : BudgeteerService<Transaction>
{
    public SubscriptionService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}