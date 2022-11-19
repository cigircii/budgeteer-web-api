namespace Cigirci.Budgeteer.Models.Entities;

using Enums.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents the user settings.
/// </summary>
///
[Table("user_settings")]
public sealed record Settings : Record
{
    [Required]
    [Column("language")]
    public Language? Language { get; set; }

    [Required]
    [Column("currency")]
    public Currency? Currency { get; set; }
}