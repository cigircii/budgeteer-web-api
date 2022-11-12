namespace Cigirci.Budgeteer.DbContext.Helper;

using Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

internal static class MetadataHelper
{
    internal static Modified BuildModified(Guid id)
    {
        return new Modified
        {
            On = DateTime.Now,
            By = id
        };
    }

    internal static Created BuildCreated(Guid id)
    {
        return new Created
        {
            On = DateTime.Now,
            By = id
        };
    }

    internal static Status BuildStatus()
    {
        return new Status
        {
            Reason = "Active",
            State = Enums.Record.State.Active
        };
    }

    internal static Owner BuildOwner()
    {
        return new Owner
        {
            Id = Guid.NewGuid(),
            Type = Enums.Record.OwnerType.User
        };
    }
}