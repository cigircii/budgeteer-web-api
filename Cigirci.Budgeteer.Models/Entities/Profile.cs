namespace Cigirci.Budgeteer.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Components.Profile;
using Enums.Profile;

[Table("profile")]
public sealed record Profile : Record
{
    [Required] public Name? Name { get; set; }

    [Column("date_of_birth")] public DateTime? Birthday { get; set; }

    [Column("sex")] public Gender? Sex { get; set; }

    [Required] [Column("email")] public string? Email { get; set; }

    [Required]
    [Column("balance", TypeName = "decimal(19,4)")]
    public decimal Balance { get; set; }

    [Required] [Column("account_id")] public Guid Account { get; set; }
}