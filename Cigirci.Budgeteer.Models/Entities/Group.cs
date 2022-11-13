namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("group")]
public record Group : Record
{
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Represents the current amount that the group holds.
    /// </summary>
    [Column("amount", TypeName = "decimal(19,4)")]
    public double Amount { get; set; }
}
