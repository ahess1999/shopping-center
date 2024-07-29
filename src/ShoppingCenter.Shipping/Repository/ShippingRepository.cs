using Microsoft.EntityFrameworkCore;
using ShoppingCenter.Data;

namespace ShoppingCenter.Shipping.Repository;

public class ShippingRepository(AppDbContext dbContext) : IShippingRepository
{
    public async Task<bool> ShipItem(int orderId)
    {
        var order = await dbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();

        if (order != null)
        {
            order.IsShipped = true;

            dbContext.SaveChanges();

            return true;
        }

        return false;
    }
}