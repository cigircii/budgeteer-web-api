namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a saving or repayment goal.
/// </summary>
[Table("goal")]
public sealed record Goal : Record
{
    [Required]
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Represents the amount to be saved or repaid.
    /// </summary>
    [Column("amount", TypeName = "decimal(19,4)")]
    public double Amount { get; set; }

    /// <summary>
    /// Represents the current amount for this goal
    /// </summary>
    [Column("balance", TypeName = "decimal(19,4)")]
    public double Balance { get; set; }
}
