﻿namespace Cigirci.Budgeteer.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("company")]
public sealed record Company : Record
{
    [Required]
    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
