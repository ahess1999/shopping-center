using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Service;

public interface IProductService
{
    public Task<IEnumerable<Product>> FetchProducts();
}