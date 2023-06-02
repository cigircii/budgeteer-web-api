namespace Cigirci.Budgeteer.Models.Entities;

using Enums.Subscription;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("subscription")]
public sealed record Subscription : Record
{
    [Required]
    [Column("name")]
    public required string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("recurrence")]
    public Timeframe? Recurrence { get; set; }

    [Column("due_date")]
    public DateTime? Due { get; set; }

    [Column("start_date")]
    public DateTime? Start { get; set; }

    [Column("end_date")]
    public DateTime? End { get; set; }

    [Required]
    [Column("active")]
    public required bool Active { get; set; }
}