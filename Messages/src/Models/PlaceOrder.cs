﻿namespace Messages.Models;

public class PlaceOrder:ICommand
{
    public string OrderId { get; set; }
}
