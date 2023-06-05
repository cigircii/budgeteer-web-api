namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Company;

using System.ComponentModel.DataAnnotations;

public record UpdateCompany
{
    [Required] public string? Name { get; set; }
    public string? Description { get; set; }
}