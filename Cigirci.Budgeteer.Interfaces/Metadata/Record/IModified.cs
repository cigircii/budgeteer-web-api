namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

internal interface IModified
{
    public DateTime On { get; set; }
    public Guid By { get; set; }
}