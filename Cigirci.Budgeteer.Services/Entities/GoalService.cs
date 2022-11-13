namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class GoalService : BudgeteerService<Transaction>
{
    public GoalService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}