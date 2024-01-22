using MassTransit;
using MassTransitTests.Consumers;
using MassTransitTests.Core.GUI;
using MassTransitTests.Core.Lexicon;
using MassTransitTests.Core.Models;
using Microsoft.Extensions.Hosting;


UserConsoleInteractions.SetConsoleHeader(Consts.CONSUMER);
string exchangeType = UserConsoleInteractions.GetExchangeType();

var hostBuilder = Host.CreateApplicationBuilder();
hostBuilder.Environment.ApplicationName = "MassTransit Consumer";
hostBuilder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("192.168.50.49", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });



        cfg.ReceiveEndpoint(System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(nameof(Message))+ Guid.NewGuid().ToString(), (config) =>
        {
            config.AutoDelete = true;
            config.ExchangeType = exchangeType;
            config.Consumer<MessageConsumer>();

        });
    });
});

Console.WriteLine("Host starting");
await hostBuilder.Build().RunAsync();
Console.WriteLine("Host stopped");



