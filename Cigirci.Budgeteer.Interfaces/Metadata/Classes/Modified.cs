namespace Cigirci.Budgeteer.Interfaces.Metadata.Classes;

using Cigirci.Budgeteer.Interfaces.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
[ComplexType]
public record Modified : IModified
{
    [Column("modified_on")] public DateTime? On { get; set; }
    [Column("modified_by")] public Guid? By { get; set; }
}