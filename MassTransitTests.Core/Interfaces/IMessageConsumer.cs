using MassTransit;
using MassTransitTests.Core.Models;

namespace MassTransitTests.Core.Interfaces
{
    public interface IMessageConsumer: IConsumer<Message>
    {
    }
}
