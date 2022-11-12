namespace Cigirci.Budgeteer.Models.Components.Profile;

using Interfaces.Metadata.Profile;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Name : IName
{
    [Column("first_name")]
    public string? First { get; set; }

    [Column("last_name")]
    public string? Last { get; set; }
}