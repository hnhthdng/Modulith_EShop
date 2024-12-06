var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => 
    config.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

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
