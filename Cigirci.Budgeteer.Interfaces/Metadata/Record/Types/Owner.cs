namespace Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

using Cigirci.Budgeteer.Interfaces.Metadata.Record;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Owner : IOwner
{
    [Required][Column("owner_id")] public Guid Id { get; set; }
    [Required][Column("owner_type")] public int Type { get; set; }
}