using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Payment.Abstractions;
using Payment.Abstractions.UseCases;


namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentServices(this IServiceCollection services)
    {
        services.AddScoped<ICreatePaymentHandler, CreatePaymentHandler>();


        services.AddValidatorsFromAssemblyContaining<CreatePaymentCommandValidator>();

        return services;
    }
}