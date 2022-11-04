namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

internal interface IOwner
{
    public Guid Id { get; set; }
    public int Type { get; set; }
}