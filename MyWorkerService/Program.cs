using Messages.Models;

// var builder = Host.CreateApplicationBuilder(args);
// var endpointConfiguration = new EndpointConfiguration("ClientUI");
// endpointConfiguration.UseSerialization<SystemJsonSerializer>();
// var transportExtensions = endpointConfiguration.UseTransport<LearningTransport>();
// builder.UseNServiceBus(endpointConfiguration);
// var host = builder.Build();
// host.Run();

namespace MyWorkerService;

internal static class Program
{
    static async Task RunLoop(IEndpointInstance endpointInstance)
    {
        var b = true;
        while (b)
        {
            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    // Instantiate the command
                    var command = new PlaceOrder
                    {
                        OrderId = Guid.NewGuid().ToString()
                    };

                    // Send the command to the local endpoint
                    await endpointInstance.SendLocal(command);

                    break;

                case ConsoleKey.Q:
                    return;
                default:
                    await endpointInstance.Stop();
                    b = false;
                    break;
            }
        }
        Console.WriteLine("end");
    }

    static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("ClientUI");
        endpointConfiguration.UseSerialization<SystemJsonSerializer>();
        var transportExtensions = endpointConfiguration.UseTransport<LearningTransport>();
        var endpointInstance = await Endpoint.Start(endpointConfiguration);

// Replace with:
        await RunLoop(endpointInstance);
    }
}