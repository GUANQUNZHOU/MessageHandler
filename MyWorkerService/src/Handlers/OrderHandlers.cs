using Messages.Models;
using NServiceBus.Logging;

namespace MyWorkerService.Handlers;

public class OrderHandlers: IHandleMessages<PlaceOrder>
{
    private static readonly ILog Log = LogManager.GetLogger<OrderHandlers>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        Log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");
        return Task.CompletedTask;
    }
}