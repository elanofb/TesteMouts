using System.Threading.Tasks;

namespace MoutsOrder.Domain.Services
{
    public interface IMessageBusService
    {
        Task PublishEvent<T>(T @event);
    }
}
