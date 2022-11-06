namespace Cigirci.Budgeteer.Services.Helpers;

using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.Models.Entities;

public static class TransactionHelper
{
    public static Transaction Create(TransactionRequest transactionRequest)
    {
        return new Transaction
        {
            Name = transactionRequest.Name,
            Description = transactionRequest.Description,
            Amount = transactionRequest.Amount
        };
    }
}