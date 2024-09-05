using Asp.Versioning.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();
builder.Services
    .AddHighlightInstrumentation(options =>
    {
        options.ProjectId = "kgrjymnd";
        options.ServiceName = "catalog";
    });

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

app.MapDefaultEndpoints();

app.NewVersionedApi("Catalog")
   .MapCatalogApiV1();

app.UseDefaultOpenApi();
app.Run();
