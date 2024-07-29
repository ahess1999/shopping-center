using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Service;

public interface IOrderService
{
    public Task<bool> OrderItem(int productId);

    public Task<IEnumerable<Order>> FetchOrders();
}