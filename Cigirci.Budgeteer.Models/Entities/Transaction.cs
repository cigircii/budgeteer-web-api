namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public record Transaction : Record
{
    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
