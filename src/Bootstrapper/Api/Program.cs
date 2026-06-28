using Shared.Exception.Handler;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCarter(configurator: config =>
// {
//     var catalogModules = typeof(CatalogModule).Assembly.GetTypes()
//         .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();
//
//     config.WithModules(catalogModules);
// });

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

//Add services to the container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

//Configure the HTTP request pipeline.
app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.UseExceptionHandler(options => { });

app.Run();