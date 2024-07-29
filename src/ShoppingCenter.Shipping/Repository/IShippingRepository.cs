namespace ShoppingCenter.Shipping.Repository;

public interface IShippingRepository
{
    public Task<bool> ShipItem(int orderId);
}