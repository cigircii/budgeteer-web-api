namespace Cigirci.Budgeteer.Interfaces.Metadata.Record;

using Enums.Record;

public interface IOwner
{
    public Guid? Id { get; set; }
    public OwnerType? Type { get; set; }
}