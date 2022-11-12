namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

public interface ICreated
{
    public DateTime On { get; set; }
    public Guid By { get; set; }
}