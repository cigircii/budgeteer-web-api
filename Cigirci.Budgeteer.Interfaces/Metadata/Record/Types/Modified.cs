namespace Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime On { get; set; }

    [Column("modified_by")] public Guid By { get; set; }
}