namespace Cigirci.Budgeteer.API.Controllers;

using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Properties;
using Services.Entities;
using Swashbuckle.AspNetCore.Annotations;

[Authorize]
[ODataQueryParameterBinding]
[ODataRouteComponent(ODataProperties.ODataRoutePrefix)]
public class CompanyController : ODataController
{
    private readonly CompanyService? _companyService;

    public CompanyController(CompanyService? companyService = null)
    {
        _companyService = companyService;
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/companies({id})")]
    [SwaggerOperation("Get company", "Retrieve a specific company", OperationId = "Company.Get")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Company>> GetCompany(Guid id, ODataQueryOptions<Company> query)
    {
        return Ok();
    }

    [EnableQuery]
    [HttpGet(ODataProperties.ODataRoutePrefix + "/companies")]
    [SwaggerOperation("List companies", "Retrieves a list of companies", OperationId = "Company.List")]
    [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies(ODataQueryOptions<Company> query)
    {
        return Ok();
    }
}