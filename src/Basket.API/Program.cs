var builder = WebApplication.CreateBuilder(args);

builder.AddBasicServiceDefaults();
builder.AddApplicationServices();
builder.Services
    .AddHighlightInstrumentation(options =>
    {
        options.ProjectId = "kgrjymnd";
        options.ServiceName = "basket";
    });

builder.Services.AddGrpc();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGrpcService<BasketService>();

app.Run();
