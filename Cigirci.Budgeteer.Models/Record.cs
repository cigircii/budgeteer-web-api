namespace Cigirci.Budgeteer.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Interfaces;
using Interfaces.Metadata.Classes;

/// <summary>
/// Represents a record in the database.
/// </summary>
public record Record : IRecord
{
    [Key]
    [Required]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Owner Owner { get; set; }

    [Required]
    public Status Status { get; set; }

    [Required]
    public Created Created { get; set; }

    [Required]
    public Modified Modified { get; set; }
}
