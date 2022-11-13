namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums.Profile;

/// <summary>
/// Represents the user settings.
/// </summary>
/// 
[Table("user_settings")]
public record Settings : Record
{
    [Required]
    [Column("language")]
    public Language? Language { get; set; }

    [Required]
    [Column("currency")]
    public Currency? Currency { get; set; }
}
