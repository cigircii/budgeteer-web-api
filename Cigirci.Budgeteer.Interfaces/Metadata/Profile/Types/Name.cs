namespace Cigirci.Budgeteer.Interfaces.Metadata.Profile.Types;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

[Owned]
public record Name : IName
{
    [Column("first_name")]
    public string? First { get; set; }

    [Column("last_name")]
    public string? Last { get; set; }
}
