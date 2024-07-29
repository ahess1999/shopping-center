using Microsoft.EntityFrameworkCore;
using ShoppingCenter.Data;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Repository;

public class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async Task<int> OrderItem(int productId)
    {
        var order = new Order(productId, false);

        await dbContext.AddAsync(order);

        dbContext.SaveChanges();

        return order!.Id;
    }

    public async Task<IEnumerable<Order>> FetchOrders()
    {
        return await dbContext.Orders.ToListAsync();
    }
}