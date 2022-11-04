namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using Metadata;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Owner : IOwner
{
    [Required][Column("owner_id")] public Guid Id { get; set; }
    [Required][Column("owner_type")] public int Type { get; set; }
}