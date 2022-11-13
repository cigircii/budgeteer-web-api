namespace Cigirci.Budgeteer.Services.Entities;

using Cigirci.Budgeteer.DbContext;
using Models.Entities;

public class MemberService : BudgeteerService<Transaction>
{
    public MemberService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }
}