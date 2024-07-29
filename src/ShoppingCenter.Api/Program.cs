using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ShoppingCenter.Api.Repository;
using ShoppingCenter.Api.Service;
using ShoppingCenter.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseFastEndpoints(c => {
    c.Endpoints.RoutePrefix = "api";
});

app.Run();