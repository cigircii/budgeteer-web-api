namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

using Enums.Record;

public interface IStatus
{
    string? Reason { get; set; }
    public State State { get; set; }
}