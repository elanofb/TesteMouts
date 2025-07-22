using Rebus.Handlers;
using System.Threading.Tasks;
using MoutsOrder.Domain.Events;
using Microsoft.Extensions.Logging;

namespace MoutsOrder.Application.EventHandlers
{
    public class OrderCreatedEventHandler : IHandleMessages<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventHandler> _logger;

        public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(OrderCreatedEvent message)
        {
            _logger.LogInformation($"Novo pedido criado: {message.OrderId}, Cliente: {message.Customer}, Cliente Externo: {message.ExternalId}, Total: {message.TotalValue}");
            await Task.CompletedTask;
        }
    }
}
