namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("transaction")]
public sealed record Transaction : Record
{
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Required]
    [Column("amount", TypeName = "decimal(19,4)")]
    public decimal Amount { get; set; }
}