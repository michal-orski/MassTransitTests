using MassTransit;
using MassTransitTests.Core.Interfaces;
using MassTransitTests.Core.Models;

namespace MassTransitTests.Consumers
{
    internal class MessageConsumer : IMessageConsumer
    {

        private readonly Guid _id = Guid.NewGuid();
        public Task Consume(ConsumeContext<Message> context)
        {
            
            Console.WriteLine($"[{_id}]    =>     {context.Message}");
            return Task.CompletedTask;
        }
    }
}
