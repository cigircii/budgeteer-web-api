namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class SettingsService : BudgeteerService<Transaction>
{
    public SettingsService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}