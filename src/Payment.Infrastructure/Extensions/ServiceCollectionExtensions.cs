using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payment.Abstractions;
using Payment.Abstractions.Messaging;
using Payment.Infrastructure.Context;
using Payment.Infrastructure.Messaging;
using Payment.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentSqlServer(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<PaymentDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                sql => { sql.EnableRetryOnFailure(); }));

        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IEventPublisher, OutboxEventPublisher>();

        return services;
    }
}