using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoppingCenter.Shipping.Service;

namespace ShoppingCenter.Shipping.Consumer;

public class ShippingConsumer(ILogger<ShippingConsumer> logger, IShippingService shippingService) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "kafka:9092",
            GroupId = "shipping-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, int>(config).Build();

        consumer.Subscribe("order-item");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(TimeSpan.FromSeconds(5));

                if (consumeResult == null)
                {
                    continue;
                }

                int orderId = consumeResult.Message.Value;
                shippingService.ShipItem(orderId);
            }
            catch (ConsumeException e)
            {
                logger.LogError(e.Message);
            }
        }

        return Task.CompletedTask;
    }
}