namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Goal;

using System.ComponentModel.DataAnnotations;

public record CreateGoal
{
    [Required] public string? Name { get; set; }

    public string? Description { get; set; }

    /// <summary>
    ///     Represents the amount to be saved or repaid.
    /// </summary>
    [Required] public double Amount { get; set; }

    /// <summary>
    ///     Represents the current amount for this goal
    /// </summary>
    public double? Balance { get; set; }
}