namespace Cigirci.Budgeteer.Contracts.Requests;

using System.ComponentModel.DataAnnotations;

public record TransactionRequest
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Amount { get; set; }
}