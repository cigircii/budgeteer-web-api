namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

internal interface ICreated
{
    public DateTime On { get; set; }
    public Guid By { get; set; }
}