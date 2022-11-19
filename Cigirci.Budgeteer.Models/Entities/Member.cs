namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums.Group;

/// <summary>
/// Represents a member of a group.
/// </summary>
[Table("group_member")]
public sealed record Member : Record
{
    [Required]
    [Column("group_id")]
    public Group? Group { get; set; }

    [Required]
    [Column("rank")]
    public Rank? Ranking { get; set; }
}
