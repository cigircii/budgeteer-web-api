namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums.Subscription;

[Table("subscription")]
public record Subscription : Record
{
    [Required]
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("recurrence")]
    public Timeframe? Recurrence { get; set; }

    [Column("due_date")]
    public DateTime? Due { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    [Required]
    [Column("active")]
    public bool Active { get; set; }
}
