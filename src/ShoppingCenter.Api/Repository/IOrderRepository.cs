using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Repository;

public interface IOrderRepository
{
    public Task<int> OrderItem(int productId);

    public Task<IEnumerable<Order>> FetchOrders();
}