using FastEndpoints;
using ShoppingCenter.Api.Repsonse;
using ShoppingCenter.Api.Request;
using ShoppingCenter.Api.Service;

namespace ShoppingCenter.Api.Endpoint;

public class OrderEndpoint(IOrderService orderService) : Endpoint<OrderRequest, OrderResponse>
{
    public override void Configure()
    {
        Post("order");
        AllowAnonymous();
    }

    public override async Task HandleAsync(OrderRequest req, CancellationToken ct)
    {
        var success = await orderService.OrderItem(req.ProductId);
        await SendOkAsync(new OrderResponse(success));
    }
}