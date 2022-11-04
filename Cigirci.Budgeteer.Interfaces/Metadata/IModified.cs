namespace Cigirci.Budgeteer.Interfaces.Metadata;

public interface IModified
{
    public DateTime On { get; set; }
    public Guid By { get; set; }
}