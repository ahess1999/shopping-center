using Microsoft.Extensions.Logging;
using ShoppingCenter.Shipping.Repository;

namespace ShoppingCenter.Shipping.Service;

public class ShippingService(ILogger<ShippingService> logger, IShippingRepository shippingRepository) : IShippingService
{
    public async void ShipItem(int orderId)
    {
        await Task.Delay(10000);
        var success = await shippingRepository.ShipItem(orderId);

        if (success)
        {
            logger.LogInformation($"Order #{orderId} shipped");
        } 
        else
        {
            logger.LogInformation($"Order #{orderId} failed to ship");
        }
    }
}