using Basket;
using Catalog;
using Ordering;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogModule(builder.Configuration)
                .AddBasketModule(builder.Configuration)
                .AddOrderingModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
 
app.UseCatalogModule()
   .UseBasketModule()
   .UseOrderingModule();

app.Run();
