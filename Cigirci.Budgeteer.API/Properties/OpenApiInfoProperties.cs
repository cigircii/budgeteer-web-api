namespace Cigirci.Budgeteer.API.Properties;

using Microsoft.OpenApi.Models;

internal record OpenApiInfoProperties
{
    internal const string Title = "Budgeteer";
    internal const string Version = "v1";
    internal const string Description = "Budgeteer API";

    internal static readonly OpenApiContact Contact = new()
    {
        Name = "Fatih Cigirci",
        Email = "fatih@cigirci.dev"
    };
}