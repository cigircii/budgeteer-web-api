namespace Cigirci.Budgeteer.Interfaces.Metadata;

internal interface IOwner
{
    public Guid Id { get; set; }
    public int Type { get; set; }
}