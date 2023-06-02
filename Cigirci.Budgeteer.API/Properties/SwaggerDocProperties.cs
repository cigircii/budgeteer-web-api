namespace Cigirci.Budgeteer.API.Properties;

internal record SwaggerDocProperties
{
    internal const string WebApiDocsAuthId = "Bearer";
    internal const string WebApiDocsName = "Budgeteer Documentation";
    internal const string WebApiDocsDescription = "Budgeteer API";

    internal const string SwaggerEndPoint = "/swagger/v1/swagger.json";
    internal const string SwaggerEndPointVersion = "Budgeteer API v1";
}