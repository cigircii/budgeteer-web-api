namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class GroupService : BudgeteerService<Transaction>
{
    public GroupService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}