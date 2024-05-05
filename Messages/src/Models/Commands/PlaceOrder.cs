namespace Messages.Models.Commands;

public class PlaceOrder:ICommand
{
    public string OrderId { get; set; }
}
