namespace Cigirci.Budgeteer.Models.Components.Profile;

using System.ComponentModel.DataAnnotations.Schema;
using Interfaces.Metadata.Profile;
using Microsoft.EntityFrameworkCore;

[Owned]
public record Name : IName
{
    [Column("first_name")] public string? First { get; set; }

    [Column("last_name")] public string? Last { get; set; }
}