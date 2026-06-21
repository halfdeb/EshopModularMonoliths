namespace Catalog.Products.EventHandlers;

public class ProductPriceChangeEventHandler(ILogger<ProductPriceChangeEventHandler> logger)
    : INotificationHandler<ProductPriceChangeEvent>
{
    public Task Handle(ProductPriceChangeEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}