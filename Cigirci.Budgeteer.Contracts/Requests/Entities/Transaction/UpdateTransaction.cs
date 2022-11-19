namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Transaction;

using Cigirci.Budgeteer.Enums.Record;

public class UpdateTransaction
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public State? State { get; set; }
}
