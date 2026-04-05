
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCarterWithAssemplies(typeof(CatalogModule).Assembly);

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

app.MapCarter();

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();