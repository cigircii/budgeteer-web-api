namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents the user settings.
/// </summary>
/// 
[Table("user_settings")]
public record Settings : Record
{
}
