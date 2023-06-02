namespace Cigirci.Budgeteer.Services.Entities;

using DbContext;
using Models.Entities;

public class CompanyService : BudgeteerService<Company>
{
    public CompanyService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}