using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(
    ILogger<OrderCreatedEventHandler> logger,
    IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);
        var featureIsEnabled = await featureManager.IsEnabledAsync("OrderFullfilment");
        if (!featureIsEnabled) return;
        var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}
