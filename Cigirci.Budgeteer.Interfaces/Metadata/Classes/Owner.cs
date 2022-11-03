namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Metadata;

[Owned]
public record Owner : IOwner
{
    [Required][Column("owner_id")] public Guid Id { get; set; }
    [Required][Column("owner_type")] public int Type { get; set; }
}
