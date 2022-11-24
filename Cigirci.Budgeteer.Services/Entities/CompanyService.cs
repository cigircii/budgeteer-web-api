namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class CompanyService : BudgeteerService<Transaction>
{
    public CompanyService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}