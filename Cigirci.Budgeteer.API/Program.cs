using System.Text;
using System.Text.Json.Serialization;
using Cigirci.Budgeteer.API.Filters;
using Cigirci.Budgeteer.API.Properties;
using Cigirci.Budgeteer.DbContext;
using Cigirci.Budgeteer.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
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

//TODO: Fix $expand to work properly
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
            //.Expand()
            .SetMaxTop(5000);
    });

//TODO: Add hosted service
//TODO: Add services separately
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<BudgeteerContext>();
//builder.Services.AddScoped<BudgeteerService>();
builder.Services.AddScoped<TransactionService>();

//TODO: Add swagger separately
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

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

    c.EnableAnnotations();

    c.OperationFilter<OperationCleanFilter>();
    c.RequestBodyFilter<RequestBodyCleanFilter>();
    c.SchemaFilter<SchemaCleanFilter>();
    c.DocumentFilter<DocumentCleanFilter>();
});

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

//TODO: Set-up development pipeline separately
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