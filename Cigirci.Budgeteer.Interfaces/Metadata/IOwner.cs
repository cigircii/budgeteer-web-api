namespace Cigirci.Budgeteer.Interfaces.Metadata;

public interface IOwner
{
    public Guid Id { get; set; }
    public int Type { get; set; }
}