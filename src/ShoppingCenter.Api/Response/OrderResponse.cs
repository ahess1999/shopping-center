namespace ShoppingCenter.Api.Repsonse;

public class OrderResponse
{
    public bool Success { get; set; }

    public OrderResponse(bool success)
    {
        this.Success = success;
    }
}