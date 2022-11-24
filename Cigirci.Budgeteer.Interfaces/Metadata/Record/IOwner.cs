namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

using Cigirci.Budgeteer.Enums.Record;

public interface IOwner
{
    public Guid? Id { get; set; }
    public OwnerType? Type { get; set; }
}