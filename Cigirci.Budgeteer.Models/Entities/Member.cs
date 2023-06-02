namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums.Group;

/// <summary>
///     Represents a member of a group.
/// </summary>
[Table("group_member")]
public sealed record Member : Record
{
    [Required] [Column("group_id")] public Group? Group { get; set; }

    [Required] [Column("rank")] public Rank? Ranking { get; set; }
}