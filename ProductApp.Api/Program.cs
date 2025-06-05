using Microsoft.EntityFrameworkCore;
using ProductApp.Api;
using ProductApp.Api.EndpointMappings;
using ProductApp.Application;
using ProductApp.Application.Common;
using ProductApp.Infrastructure.Persistance.EntityFrameworkCore;
using ProductApp.Infrastructure.Persistance.EntityFrameworkCore.Products;

var builder = WebApplication.CreateBuilder(args);


builder.Services

    .AddSwaggerExt();



builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ProductDbContext>());


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(ProductApp.Application.Products.Commands.CreateProductCommand).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExt();
}

app.UseHttpsRedirection();

app.MapProductEndpoints();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    await context.Database.EnsureCreatedAsync();
}

app.Run();