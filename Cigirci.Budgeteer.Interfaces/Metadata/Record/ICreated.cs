namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

public interface ICreated
{
    public DateTime On { get; init; }
    public Guid By { get; init; }
}