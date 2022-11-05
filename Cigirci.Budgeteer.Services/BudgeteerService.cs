namespace Cigirci.Budgeteer.Services;

using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.DbContext;

public class BudgeteerService
{
    public BudgeteerContext? _budgeteerContext { get; set; }

    public BudgeteerService(BudgeteerContext? budgeteerContext)
    {
        _budgeteerContext = budgeteerContext;
    }

    public void CreateTransaction(TransactionRequest transactionRequest)
    {
        //_budgeteerContext.Transactions.Add(transaction);
        //_budgeteerContext.SaveChanges();
    }
}