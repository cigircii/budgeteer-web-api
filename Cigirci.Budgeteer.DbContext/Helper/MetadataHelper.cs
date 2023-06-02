namespace Cigirci.Budgeteer.DbContext.Helper;

using Enums.Record;
using Interfaces.Metadata.Record.Types;
using Models.Components.Metadata;

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
            State = State.Active
        };
    }

    internal static Owner BuildOwner(Guid id)
    {
        return new Owner
        {
            Id = id,
            Type = OwnerType.User
        };
    }
}