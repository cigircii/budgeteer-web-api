namespace Cigirci.Budgeteer.Interfaces;
using Cigirci.Budgeteer.Interfaces.Metadata;
using Cigirci.Budgeteer.Interfaces.Metadata.Classes;

public interface IRecord
{
    public Guid Id { get; set; }
    public Owner Owner { get; set; }
    public Status Status { get; set; }
    public Created Created { get; set; }
    public Modified Modified { get; set; }
}
