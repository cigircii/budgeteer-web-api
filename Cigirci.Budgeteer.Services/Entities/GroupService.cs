namespace Cigirci.Budgeteer.Services.Entities;

using DbContext;
using Models.Entities;

public class GroupService : BudgeteerService<Transaction>
{
    public GroupService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}