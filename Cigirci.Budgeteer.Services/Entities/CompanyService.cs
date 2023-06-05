namespace Cigirci.Budgeteer.Services.Entities;

using Contracts.Requests.Entities.Company;
using DbContext;
using Models.Entities;

public class CompanyService : BudgeteerService<Company>
{
    public CompanyService(BudgeteerContext? budgeteerContext = null) : base(budgeteerContext)
    {
    }

    public async Task<Company?> CreateCompany(CreateCompany createRequest)
    {
        var company = new Company
        {
            Name = createRequest.Name,
            Description = createRequest.Description
        };

        return await Add(company);
    }

    public async Task<Company?> UpdateCompany(Guid id, UpdateCompany updateRequest)
    {
        var company = await Get(id);
        if (company is null) return null;

        if (!string.IsNullOrWhiteSpace(updateRequest.Name))
        {
            company.Name = updateRequest.Name;
        }

        if (!string.IsNullOrWhiteSpace(updateRequest.Description))
        {
            company.Description = updateRequest.Description;
        }

        return await Update(company);
    }
}