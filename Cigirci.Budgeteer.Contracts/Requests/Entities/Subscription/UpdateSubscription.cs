namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Subscription;

using Enums.Subscription;

public record UpdateSubscription
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Timeframe? Recurrence { get; set; }

    public DateTime? Due { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public bool? Active { get; set; }
}