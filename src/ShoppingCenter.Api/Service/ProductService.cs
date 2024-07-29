using ShoppingCenter.Api.Repository;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Service;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<IEnumerable<Product>> FetchProducts()
    {
        return await productRepository.FetchProducts();
    }
}