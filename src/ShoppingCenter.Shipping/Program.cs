using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCenter.Data;
using ShoppingCenter.Shipping.Consumer;
using ShoppingCenter.Shipping.Repository;
using ShoppingCenter.Shipping.Service;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddHostedService<ShippingConsumer>();
builder.Services.AddTransient<IShippingService, ShippingService>();
builder.Services.AddTransient<IShippingRepository, ShippingRepository>();

builder.Build().Run();