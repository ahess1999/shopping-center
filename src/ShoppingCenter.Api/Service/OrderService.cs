using Confluent.Kafka;
using ShoppingCenter.Api.Repository;
using ShoppingCenter.Data.Entity;

namespace ShoppingCenter.Api.Service;

public class OrderService(ILogger<OrderService> logger, IOrderRepository orderRepository) : IOrderService
{
    public async Task<bool> OrderItem(int productId)
    {
        int orderId = await orderRepository.OrderItem(productId);

        var config = new ProducerConfig
        {
            BootstrapServers = "kafka:9092",
            AllowAutoCreateTopics = true,
            Acks = Acks.All
        };

        using var producer = new ProducerBuilder<Null, int>(config).Build();

        try 
        {
            var result = await producer.ProduceAsync("order-item", new Message<Null, int>{ Value = orderId });
        } 
        catch (ProduceException<Null, int> e) 
        {
            logger.LogError($"{e.Error.Reason}");
        }

        producer.Flush();

        return true;
    }
    
    public async Task<IEnumerable<Order>> FetchOrders()
    {
        return await orderRepository.FetchOrders();
    }
}