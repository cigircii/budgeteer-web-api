namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using Cigirci.Budgeteer.Interfaces.Metadata;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Created : ICreated
{
    [Required]
    [Column("created_on")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime On { get; set; }

    [Required][Column("created_by")] public Guid By { get; set; }
}