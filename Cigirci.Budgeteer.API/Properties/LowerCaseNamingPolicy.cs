namespace Cigirci.Budgeteer.API.Properties;

using System.Text.Json;

public class LowerCaseNamingPolicy : JsonNamingPolicy
{
    //TODO: Check why this isn't working
    public override string ConvertName(string name)
    {
        return name.ToLower();
    }
}
