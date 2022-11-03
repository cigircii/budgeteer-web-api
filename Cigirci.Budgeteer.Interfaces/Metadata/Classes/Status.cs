namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cigirci.Budgeteer.Enums.Record;
using Cigirci.Budgeteer.Interfaces.Metadata;
using Microsoft.EntityFrameworkCore;


[Keyless]
[ComplexType]
public record Status : IStatus
{
    [Column("status")] public string? Reason { get; set; }
    [Required][Column("state")] public State State { get; set; }
}