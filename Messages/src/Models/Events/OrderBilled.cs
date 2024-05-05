namespace Messages.Models.Events;

public class OrderBilled : IEvent
{
    public string OrderId { get; set; }
}