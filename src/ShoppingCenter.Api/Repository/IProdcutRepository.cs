using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> FetchProducts();
}