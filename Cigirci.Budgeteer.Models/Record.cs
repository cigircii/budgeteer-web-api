namespace Cigirci.Budgeteer.Models;

using Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;
using Components.Metadata;
using Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents a record in the database.
/// </summary>
public abstract record Record : IRecord
{
    [Key]
    [Required]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required]
    public Owner? Owner { get; init; }

    [Required]
    public Status? Status { get; init; }

    [Required]
    public Created? Created { get; init; }

    [Required]
    public Modified? Modified { get; init; }
}