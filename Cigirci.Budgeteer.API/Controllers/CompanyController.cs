namespace Cigirci.Budgeteer.API.Controllers;

using Contracts.Requests.Entities.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models.Entities;
using Models.Validation;
using Properties;
using Services.Entities;
using Swashbuckle.AspNetCore.Annotations;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class CompanyController : ODataController
{
    private readonly ILogger<CompanyController>? _logger;
    private readonly CompanyService? _companyService;

    public CompanyController(CompanyService? companyService = null,
        ILogger<CompanyController>? logger = null)
    {
        _companyService = companyService;
        _logger = logger;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/companies({id})")]
    [SwaggerOperation("Get company", "Retrieve a specific company", OperationId = "Company.Get")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Company>> GetCompany(Guid id, ODataQueryOptions<Company> query)
    {
        if (_companyService == null) return NotFound();

        var company = await _companyService.Get(id);
        if (company is null) return NotFound();

        return Ok(company);
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/companies")]
    [SwaggerOperation("List companies", "Retrieves a list of companies", OperationId = "Company.List")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies(ODataQueryOptions<Company> query)
    {
        if (_companyService == null) return NotFound();
        var companies = await _companyService.GetAll();

        return Ok(companies);
    }
    
    [EnableQuery]
    [HttpPost(ODataProperties.ODataRoutePrefix + "/companies")]
    [SwaggerOperation("Create company", "Create a company", OperationId = "Company.Create")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Company>> CreateCompany([FromBody] CreateCompany createRequest)
    {
        if (_companyService is null) return NotFound();
        if (!ModelState.IsValid) return BadRequest(ModelState);
    
        var company = await _companyService.CreateCompany(createRequest);
        return CreatedAtAction("CreateCompany", company);
    }
    
    [EnableQuery]
    [HttpPut(ODataProperties.ODataRoutePrefix + "/companies({id})")]
    [SwaggerOperation("Update company", "Update a company", OperationId = "Company.Update")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Company>> UpdateSubscription(Guid id,
        [FromBody] UpdateCompany updateRequest)
    {
        if (_companyService is null) return NotFound();

        var properties = updateRequest.GetType().GetProperties();
        var requestIsInvalid = properties.All(property => property.GetValue(updateRequest) == null);
        if (requestIsInvalid) return BadRequest("No properties found to update");

        var company = await _companyService.UpdateCompany(id, updateRequest);
        if (company == null) return NotFound();

        return Ok(company);
    }
    
    [HttpDelete(ODataProperties.ODataRoutePrefix + "/companies({id})")]
    [SwaggerOperation("Delete company", "Delete a company", OperationId = "Company.Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        if (_companyService == null) return NotFound();

        var company = await _companyService.Get(id);
        if (company == null) return NotFound();

        await _companyService.Delete(id);

        return Ok();
    }
}