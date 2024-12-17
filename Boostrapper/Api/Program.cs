var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => 
    config.ReadFrom.Configuration(context.Configuration));

//common services: carter, mediatr, fluentvalidation, masstransit
var catalogAssembly = typeof(CatalogModule).Assembly;
var basketAssembly = typeof(BasketModule).Assembly;

builder.Services.AddCarterWithAssemblies(catalogAssembly, basketAssembly);

builder.Services.AddMediatRWithAssemblies(catalogAssembly, basketAssembly);

builder.Services.AddValidatorsFromAssemblies([catalogAssembly, basketAssembly]);

builder.Services.AddCatalogModule(builder.Configuration)
                .AddBasketModule(builder.Configuration)
                .AddOrderingModule(builder.Configuration);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter(); 

app.UseSerilogRequestLogging();

app.UseExceptionHandler(option => { });

app.UseCatalogModule()
   .UseBasketModule()
   .UseOrderingModule();

app.Run();
