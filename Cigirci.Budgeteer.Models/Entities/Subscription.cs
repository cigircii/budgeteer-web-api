namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums.Subscription;

[Table("subscription")]
public sealed record Subscription : Record
{
    [Required] [Column("name")] public required string? Name { get; set; }

    [Column("description")] public string? Description { get; set; }

    [Column("recurrence")] public Timeframe? Recurrence { get; set; }

    [Column("due_date")] public DateTime? Due { get; set; }

    [Column("start_date")] public DateTime? Start { get; set; }

    [Column("end_date")] public DateTime? End { get; set; }

    /// <summary>
    /// This field is meant to indicate whether the subscription itself is still active (on-going) or has been cancelled
    /// This field is not to be confused with whether the actual record itself is active or not
    /// The state of the record itself is defined (counts for all 'record' entities) within the 'Status' class inherited from 'Record' (abstract) class
    /// </summary>
    [Required] [Column("active")] public required bool Active { get; set; }
}