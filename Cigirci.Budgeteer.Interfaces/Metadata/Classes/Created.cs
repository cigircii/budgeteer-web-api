namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using Cigirci.Budgeteer.Interfaces.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Owned]
public record Created : ICreated
{
    [Required]
    [Column("created_on")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime On { get; set; }
    
    [Required][Column("created_by")] public Guid By { get; set; }
}
