using Microsoft.OpenApi.Models;
using NuGet.Protocol;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cigirci.Budgeteer.API.Filters;

public class DocumentCleanFilter : IDocumentFilter
{
    private const string SchemaV3Prefix = "#/components/schemas/";
    private readonly Dictionary<string, int> countByDefinitionReference = new();
    private OpenApiDocument? _swaggerDoc = null;

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        this._swaggerDoc = swaggerDoc;
        bool anyDefinitionRemoved;

        // First loop through all references including the references used in schemas
        do
        {
            anyDefinitionRemoved = RemoveUnused(swaggerDoc, true);
        } while (anyDefinitionRemoved);

        // Second loop only through operations to also clear schemas that are never used in any operation
        do
        {
            anyDefinitionRemoved = RemoveUnused(swaggerDoc, false);
        } while (anyDefinitionRemoved);
    }

    private bool RemoveUnused(OpenApiDocument swaggerDoc, bool includeAllSchemas)
    {
        //countByDefinitionReference.Clear();
        foreach (var refWithSchema in swaggerDoc.Components.Schemas)
        {
            countByDefinitionReference[SchemaV3Prefix + refWithSchema.Key] = 0;
        }

        foreach (var pathItem in swaggerDoc.Paths.Values)
        {
            AddParameterReferenceCount(pathItem.Parameters, !includeAllSchemas, 0);
            AddOperationReferenceCount(pathItem.Operations.Values, !includeAllSchemas, 0);
        }

        if (includeAllSchemas)
        {
            AddSchemaCollectionReferenceCount(swaggerDoc.Components.Schemas.Values, !includeAllSchemas, 0);
        }
        else
        {
            // Only include the schema if it was referenced by an operation
            AddSchemaCollectionReferenceCount(swaggerDoc.Components.Schemas.Where(x => countByDefinitionReference[SchemaV3Prefix + x.Key] != 0).Select(x => x.Value), !includeAllSchemas, 0);
        }

        var anyDefinitionRemoved = false;

        foreach (var countByRef in countByDefinitionReference.Where(x => x.Value == 0))
        {
            var definitionKey = countByRef.Key.Replace(SchemaV3Prefix, string.Empty);
            if (swaggerDoc.Components.Schemas.Remove(definitionKey))
            {
                anyDefinitionRemoved = true;
            }
        }

        foreach (var countByRef in countByDefinitionReference.Where(x => x.Value == 1))
        {
            var definitionKey = countByRef.Key.Replace(SchemaV3Prefix, string.Empty);

            // Check if schema only refers to itself
            if (swaggerDoc.Components.Schemas.TryGetValue(definitionKey, out OpenApiSchema? openApiSchema)
                && CountReferencesToSpecificSchemaInSchema(openApiSchema, countByRef.Key) != 0
                && swaggerDoc.Components.Schemas.Remove(definitionKey))
            {
                anyDefinitionRemoved = true;
            }
        }

        return anyDefinitionRemoved;
    }

    private void AddSchemaCollectionReferenceCount(IEnumerable<OpenApiSchema> definitions, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        foreach (var definition in definitions)
        {
            AddSchemaReferenceCount(definition, alsoCountSubSchemas, subSchemaDepth);
        }
    }

    private void AddOperationReferenceCount(IEnumerable<OpenApiOperation> operations, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        if (operations == null)
        {
            return;
        }

        foreach (var operation in operations)
        {
            AddParameterReferenceCount(operation.Parameters, alsoCountSubSchemas, subSchemaDepth);
            AddRequestReferenceCount(operation.RequestBody, alsoCountSubSchemas, subSchemaDepth);
            AddResponseReferenceCount(operation.Responses, alsoCountSubSchemas, subSchemaDepth);
        }
    }

    private void AddRequestReferenceCount(OpenApiRequestBody requestBody, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        if (requestBody == null)
        {
            return;
        }

        if (requestBody.Reference != null && !string.IsNullOrWhiteSpace(requestBody.Reference.ReferenceV3))
        {
            countByDefinitionReference[requestBody.Reference.ReferenceV3]++;
            if (alsoCountSubSchemas && _swaggerDoc is not null &&
                _swaggerDoc.Components.Schemas.TryGetValue(requestBody.Reference.Id, out OpenApiSchema? subSchema))
            {
                AddSchemaReferenceCount(subSchema, alsoCountSubSchemas, subSchemaDepth + 1);
            }
        }

        foreach (var content in requestBody.Content.Values)
        {
            AddSchemaReferenceCount(content.Schema, alsoCountSubSchemas, subSchemaDepth);
        }
    }

    private void AddResponseReferenceCount(IDictionary<string, OpenApiResponse> responsesByHttpStatus, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        if (responsesByHttpStatus == null)
        {
            return;
        }

        foreach (var response in responsesByHttpStatus.Values)
        {
            foreach (var content in response.Content.Values)
            {
                AddSchemaReferenceCount(content.Schema, alsoCountSubSchemas, subSchemaDepth);
            }
        }
    }

    private void AddParameterReferenceCount(IList<OpenApiParameter> parameters, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        if (parameters == null)
        {
            return;
        }

        foreach (var param in parameters)
        {
            AddSchemaReferenceCount(param.Schema, alsoCountSubSchemas, subSchemaDepth);
        }
    }

    private void AddSchemaReferenceCount(OpenApiSchema schema, bool alsoCountSubSchemas, int subSchemaDepth)
    {
        if (schema == null)
        {
            return;
        }

        if (schema.Properties.ContainsKey("agreement"))
        {
        }

        if (alsoCountSubSchemas && subSchemaDepth > 5)
        {
            alsoCountSubSchemas = false;
        }

        if (schema.Reference != null && !string.IsNullOrWhiteSpace(schema.Reference.ReferenceV3))
        {
            countByDefinitionReference[schema.Reference.ReferenceV3]++;
            if (alsoCountSubSchemas && _swaggerDoc is not null &&
                _swaggerDoc.Components.Schemas.TryGetValue(schema.Reference.Id, out OpenApiSchema? subSchema))
            {
                AddSchemaReferenceCount(subSchema, alsoCountSubSchemas, subSchemaDepth + 1);
            }
        }

        if (schema.Items != null && schema.Items.Reference != null && !string.IsNullOrWhiteSpace(schema.Items.Reference.ReferenceV3))
        {
            countByDefinitionReference[schema.Items.Reference.ReferenceV3]++;
            if (alsoCountSubSchemas && _swaggerDoc is not null &&
                    _swaggerDoc.Components.Schemas.TryGetValue(schema.Items.Reference.Id, out OpenApiSchema? subSchema))
            {
                AddSchemaReferenceCount(subSchema, alsoCountSubSchemas, subSchemaDepth + 1);
            }
        }

        if ((schema.Properties?.Count ?? 0) != 0)
        {
            if (schema.Properties is not null)
            {
                //Recurse into child properties
                foreach (var s in schema.Properties.Values)
                {
                    AddSchemaReferenceCount(s, alsoCountSubSchemas, subSchemaDepth);
                }
            }
        }
    }

    private int CountReferencesToSpecificSchemaInSchema(OpenApiSchema schema, string schemaName)
    {
        if (schema == null)
        {
            return 0;
        }

        int count = 0;

        if (schema.Reference != null && schema.Reference.ReferenceV3 == schemaName)
        {
            count++;
        }

        if (schema.Items != null && schema.Items.Reference != null && schema.Items.Reference.ReferenceV3 == schemaName)
        {
            count++;
        }

        if ((schema.Properties?.Count ?? 0) != 0)
        {
            if (schema.Properties is not null)
            {
                foreach (var s in schema.Properties.Values)
                {
                    count += CountReferencesToSpecificSchemaInSchema(s, schemaName);
                }
            }
        }

        return count;
    }
}