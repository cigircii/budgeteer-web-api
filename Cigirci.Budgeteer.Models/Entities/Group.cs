﻿namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("group")]
public sealed record Group : Record
{
    [Required]
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Represents the current amount that the group holds.
    /// </summary>
    [Column("amount", TypeName = "decimal(19,4)")]
    public double Amount { get; set; }
}