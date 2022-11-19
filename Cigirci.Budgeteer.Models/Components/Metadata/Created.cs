namespace Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

using Cigirci.Budgeteer.Interfaces.Metadata.Record;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Created : ICreated
{
    [Required]
    [Column("created_on")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public DateTime On { get; init; } = DateTime.Now;

    [Required][Column("created_by")] public Guid By { get; set; }
}