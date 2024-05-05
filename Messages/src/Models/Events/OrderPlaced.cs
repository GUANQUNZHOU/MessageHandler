namespace Messages.Models.Events;

public class OrderPlaced:IEvent
{
    public string OrderId { get; set; }
}