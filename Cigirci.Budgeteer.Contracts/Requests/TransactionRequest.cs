namespace Cigirci.Budgeteer.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record TransactionRequest
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public decimal Amount { get; set; }
}
