using Payment.Abstractions.Messaging;
using Payment.Infrastructure.Context;
using Payment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Messaging
{
    public class OutboxEventPublisher : IEventPublisher
    {
        private readonly PaymentDbContext _dbContext;

        public OutboxEventPublisher(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PublishAsync<TEvent>(
            TEvent @event,
            CancellationToken cancellationToken = default)
            where TEvent : class
        {
            var outboxEvent = new OutboxEvent
            {
                Type = @event.GetType().FullName!,
                Payload = JsonSerializer.Serialize(@event),
                OccurredOnUtc = DateTime.UtcNow,
                Status = "Pending"
            };

            await _dbContext.OutboxEvents.AddAsync(outboxEvent, cancellationToken);

           
        }
    }
}
