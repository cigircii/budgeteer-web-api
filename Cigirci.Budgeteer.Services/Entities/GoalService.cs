namespace Cigirci.Budgeteer.Services.Entities;

using DbContext;
using Models.Entities;

public class GoalService : BudgeteerService<Transaction>
{
    public GoalService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}