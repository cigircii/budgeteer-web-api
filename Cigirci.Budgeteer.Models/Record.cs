namespace Cigirci.Budgeteer.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cigirci.Budgeteer.Interfaces;
using Cigirci.Budgeteer.Interfaces.Metadata.Classes;

/// <summary>
/// Represents a record in the database.
/// </summary>
public record Record : IRecord
{
    [Key]
    [Required]
    [Column("id")]
    public Guid Id { get; set; }

    public Owner Owner { get; set; }

    public Status Status { get; set; }

    public Created Created { get; set; }

    public Modified? Modified { get; set; }
}
