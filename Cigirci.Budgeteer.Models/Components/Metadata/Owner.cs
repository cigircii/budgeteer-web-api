namespace Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums.Record;
using Microsoft.EntityFrameworkCore;

[Owned]
public record Owner : IOwner
{
    [Required] [Column("owner_id")] public Guid? Id { get; set; }
    [Required] [Column("owner_type")] public OwnerType? Type { get; set; }
}