namespace Cigirci.Budgeteer.API.Filters;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class OperationCleanFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        ReplaceODataClrParameters(operation, context);

        foreach (var response in operation.Responses)
        {
            RemoveExtraTypes(response.Value.Content);
        }

        if (operation.RequestBody != null)
        {
            RemoveExtraTypes(operation.RequestBody.Content);
        }
    }

    private static void ReplaceODataClrParameters(OpenApiOperation operation, OperationFilterContext context)
    {
        var odataQueryOptionsClrParam = context.MethodInfo.GetParameters().FirstOrDefault(p => p.ParameterType.Name.Contains("ODataQueryOptions"));

        if (odataQueryOptionsClrParam == null)
        {
            return;
        }

        var odataQueryOptionsParamDefinition = operation.Parameters.FirstOrDefault(p => p.Name == odataQueryOptionsClrParam.Name);
        if (odataQueryOptionsParamDefinition != null)
        {
            operation.Parameters.Remove(odataQueryOptionsParamDefinition);
        }
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "$filter",
            In = ParameterLocation.Query,
            Description = "Specify an OData v4 filter query to filter the result.",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "$top",
            In = ParameterLocation.Query,
            Description = "Specify the maximum number of records to return.",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "$orderby",
            In = ParameterLocation.Query,
            Description = "Specify an OData v4 order expression to order the result.",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "$select",
            In = ParameterLocation.Query,
            Description = "Specify an OData v4 select expression to only return selected properties.",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });

    }

    public static void RemoveExtraTypes(IDictionary<string, OpenApiMediaType> content)
    {
        // Use ToList to create a copy of the Keys so we can enumerate while also manipulating the collection
        foreach (var item in content.Keys.Where(k => k != "application/json" && k != "application/xml").ToList())
        {
            content.Remove(item);
        }
    }
}
