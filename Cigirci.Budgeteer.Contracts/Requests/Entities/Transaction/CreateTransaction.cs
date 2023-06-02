namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Transaction;

using System.ComponentModel.DataAnnotations;

public record CreateTransaction
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    [Required] public decimal Amount { get; set; }
}