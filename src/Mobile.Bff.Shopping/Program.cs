var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddHighlightInstrumentation(options =>
    {
        options.ProjectId = "kgrjymnd";
        options.ServiceName = "mobile";
    });

builder.AddServiceDefaults();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.MapDefaultEndpoints();
app.MapReverseProxy();

await app.RunAsync();
