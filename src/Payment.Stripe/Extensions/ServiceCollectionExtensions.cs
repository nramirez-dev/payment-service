using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Abstractions;
using Payment.Abstractions.Options;
using Payment.Infrastructure.Stripe;

namespace Payment.Stripe.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStripeInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<StripeOptions>(
            configuration.GetSection(StripeOptions.SectionName));

        services.AddScoped<IStripePaymentService, StripePaymentService>();

        return services;
    }
}
