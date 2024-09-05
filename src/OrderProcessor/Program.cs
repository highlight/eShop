var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddHighlightInstrumentation(options =>
    {
        options.ProjectId = "kgrjymnd";
        options.ServiceName = "orders";
    });

builder.AddBasicServiceDefaults();
builder.AddApplicationServices();

var app = builder.Build();

app.MapDefaultEndpoints();

await app.RunAsync();
