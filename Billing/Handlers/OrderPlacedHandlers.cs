using Messages.Models.Events;
using NServiceBus.Logging;

namespace Billing.Handlers;

public class OrderPlacedHandlers:IHandleMessages<OrderPlaced>
{
    private static readonly ILog Log = LogManager.GetLogger<OrderPlacedHandlers>(); 
    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        Log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");
        var orderBilled = new OrderBilled()
        {
            OrderId = message.OrderId
        };
        return context.Publish(orderBilled);
    }
}