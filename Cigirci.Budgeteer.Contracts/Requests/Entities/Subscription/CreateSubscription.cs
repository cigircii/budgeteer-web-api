namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Subscription;

using System.ComponentModel.DataAnnotations;

public record CreateSubscription
{
    [Required] public required string Name { get; set; }
    [Required] public bool Active { get; set; } = true;
}