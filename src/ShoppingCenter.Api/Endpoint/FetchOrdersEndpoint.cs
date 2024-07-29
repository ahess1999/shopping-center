using FastEndpoints;
using ShoppingCenter.Api.Service;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Endpoint;

public class FetchOrdersEndpoint(IOrderService orderService) : EndpointWithoutRequest<IEnumerable<Data.Entity.Order>>
{
    public override void Configure()
    {
        Get("orders");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(await orderService.FetchOrders());
    }
}