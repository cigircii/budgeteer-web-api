namespace Cigirci.Budgeteer.Services.Helpers;

using Cigirci.Budgeteer.Contracts.Requests;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
