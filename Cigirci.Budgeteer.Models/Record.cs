namespace Cigirci.Budgeteer.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Components.Metadata;
using Interfaces;
using Interfaces.Metadata.Record.Types;

/// <summary>
///     Represents a record in the database.
/// </summary>
public abstract record Record : IRecord
{
    [Required] public Owner Owner { get; init; } = new();

    [Required] public Status Status { get; init; } = new();

    [Required] public Created Created { get; init; } = new();

    [Required] public Modified Modified { get; init; } = new();

    [Key]
    [Required]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
}