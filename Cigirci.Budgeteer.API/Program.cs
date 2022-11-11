using Cigirci.Budgeteer.API.Filters;
using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Models.Entities;
using Cigirci.Budgeteer.Services;
using Cigirci.Budgeteer.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(authenticationScheme: JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
    }).AddOData(options =>
    {
        options.Filter()
        .Select()
        .OrderBy()
        .SetMaxTop(5000);
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<BudgeteerContext>();
builder.Services.AddScoped<BudgeteerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = OpenApiInfoProperties.Title,
            Version = OpenApiInfoProperties.Version,
            Description = OpenApiInfoProperties.Description,
            Contact = OpenApiInfoProperties.Contact
        });

    c.EnableAnnotations();

    c.OperationFilter<OperationCleanFilter>();
    c.RequestBodyFilter<RequestBodyCleanFilter>();
    c.SchemaFilter<SchemaCleanFilter>();
    c.DocumentFilter<DocumentCleanFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(SwaggerDocProperties.SwaggerEndPoint, SwaggerDocProperties.SwaggerEndPointVersion);
    });

    app.UseReDoc(options =>
    {
        options.DocumentTitle = SwaggerDocProperties.WebApiDocsName;
        options.SpecUrl = SwaggerDocProperties.SwaggerEndPoint;
        
        options.RequiredPropsFirst();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();