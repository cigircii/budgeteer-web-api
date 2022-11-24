namespace Cigirci.Budgeteer.Models.Components.Metadata;

using Cigirci.Budgeteer.Interfaces.Metadata.Record;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Modified : IModified
{
    [Required]
    [Column("modified_on")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public DateTime On { get; set; } = DateTime.Now;

    [Required][Column("modified_by")] public Guid By { get; set; }
}