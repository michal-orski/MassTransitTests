using MassTransit;
using MassTransitTests.Core.GUI;
using MassTransitTests.Core.Lexicon;
using MassTransitTests.Publishers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


UserConsoleInteractions.SetConsoleHeader(Consts.PUBLISHER);
Cache.Dictionary[Cache.Key.CountMessage] = UserConsoleInteractions.GetNumberOfMessages();
Cache.Dictionary[Cache.Key.DelayMs] = UserConsoleInteractions.GetDelayBetweenMessages();

var hostBuilder = Host.CreateApplicationBuilder();
hostBuilder.Environment.ApplicationName = "MassTransit Publisher";
hostBuilder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("192.168.50.49", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

    });
});


hostBuilder.Services.AddHostedService<PublishWorker>();

Console.WriteLine("Host starting");
await hostBuilder.Build().RunAsync();
Console.WriteLine("Host stopped");



