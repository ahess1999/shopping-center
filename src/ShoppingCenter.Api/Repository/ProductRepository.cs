using Microsoft.EntityFrameworkCore;
using ShoppingCenter.Data;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Repository;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> FetchProducts()
    {
        return await dbContext.Products.ToListAsync();
    }
}