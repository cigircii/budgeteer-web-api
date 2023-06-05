namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Goal;

using Enums.Record;

public record UpdateGoal
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    /// <summary>
    ///     Represents the amount to be saved or repaid.
    /// </summary>
    public double? Amount { get; set; }

    /// <summary>
    ///     Represents the current amount for this goal
    /// </summary>
    public double? Balance { get; set; }
    
    public State? State { get; set; }
}