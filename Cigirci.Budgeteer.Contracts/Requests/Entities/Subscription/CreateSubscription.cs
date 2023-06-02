namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Subscription;

using System.ComponentModel.DataAnnotations;
using Enums.Subscription;

public record CreateSubscription
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    public Timeframe? Recurrence { get; set; }

    public DateTime? Due { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public required bool Active { get; set; } = true;
}