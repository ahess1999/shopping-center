using FastEndpoints;
using ShoppingCenter.Api.Service;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Endpoint;

public class FetchProductsEndpoint(IProductService productService) : EndpointWithoutRequest<IEnumerable<Product>>
{
    public override void Configure()
    {
        Get("products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(await productService.FetchProducts());
    }
}