using MassTransit;
using MassTransitTests.Core.Lexicon;
using MassTransitTests.Core.Models;
using Microsoft.Extensions.Hosting;

namespace MassTransitTests.Publishers
{
    internal class PublishWorker(IPublishEndpoint publishEndpoint) : IHostedService
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Publishing messages");

            for (int i = 0; i < (int)Cache.Dictionary[Cache.Key.CountMessage]; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("STOP");
                    break;
                }

                var newMessage = new Message
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.UtcNow,
                    Text = $"Message {i}"
                };

                await _publishEndpoint.Publish(newMessage, cancellationToken);

                await Task.Delay((int)Cache.Dictionary[Cache.Key.DelayMs], cancellationToken);


                Console.WriteLine(newMessage.ToString());
            }

            Console.WriteLine("Publishing done");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
