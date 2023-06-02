namespace Cigirci.Budgeteer.Services.Entities;

using DbContext;
using Models.Entities;

public class ProfileService : BudgeteerService<Transaction>
{
    public ProfileService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}