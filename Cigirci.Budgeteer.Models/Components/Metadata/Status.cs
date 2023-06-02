namespace Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums.Record;
using Microsoft.EntityFrameworkCore;

[Owned]
public record Status : IStatus
{
    [Column("status")] public string? Reason { get; set; } = "Active";
    [Required] [Column("state")] public State State { get; set; } = State.Active;
}