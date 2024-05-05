using Messages.Models.Events;
using NServiceBus.Logging;

namespace Billing.Handlers;

public class OrderBilledHandlers:IHandleMessages<OrderBilled>
{
    private static readonly ILog Log = LogManager.GetLogger<OrderBilledHandlers>(); 
    public Task Handle(OrderBilled message, IMessageHandlerContext context)
    {
        Log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");
        return Task.CompletedTask;
    }
}