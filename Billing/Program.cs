﻿// See https://aka.ms/new-console-template for more information

namespace Billing;

internal static class Program
{
    private static async Task Main()
    {
        Console.Title = "Billing";

        var endpointConfiguration = new EndpointConfiguration("Billing");
// Choose JSON to serialize and deserialize messages
        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var transport = endpointConfiguration.UseTransport<LearningTransport>();
        
        var endpointInstance = await Endpoint.Start(endpointConfiguration);

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();

        await endpointInstance.Stop();

    }
}