using Messages.Models.Commands;
using Messages.Models.Events;
using NServiceBus.Logging;

namespace Sales.Handlers;

public class OrderHandlers: IHandleMessages<PlaceOrder>
{
    private static readonly ILog Log = LogManager.GetLogger<OrderHandlers>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        Log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

        // This is normally where some business logic would occur

        var orderPlaced = new OrderPlaced
        {
            OrderId = message.OrderId
        };
        return context.Publish(orderPlaced);
    }
}