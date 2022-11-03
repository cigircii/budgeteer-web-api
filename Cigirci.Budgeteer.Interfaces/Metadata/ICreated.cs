namespace Cigirci.Budgeteer.Interfaces.Metadata;

public interface ICreated
{
    public DateTime On { get; set; }
    public Guid By { get; set; }
}
