namespace Cigirci.Budgeteer.Models.Components.Metadata;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Interfaces.Metadata.Record;
using Microsoft.EntityFrameworkCore;

[Owned]
public record Modified : IModified
{
    [Required]
    [Column("modified_on")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public DateTime On { get; set; } = DateTime.Now;

    [Required] [Column("modified_by")] public Guid By { get; set; }
}