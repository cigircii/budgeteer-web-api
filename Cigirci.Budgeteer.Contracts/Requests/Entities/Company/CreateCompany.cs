namespace Cigirci.Budgeteer.Contracts.Requests.Entities.Company;

public record CreateCompany
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}