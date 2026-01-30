using Microsoft.Extensions.Options;
using Payment.Abstractions;
using Payment.Abstractions.Options;


using Payment.Share.DataTransferObjects.Integrations.Stripe;
using Payment.Share.DataTransferObjects.Service.Results;
using Stripe;

namespace Payment.Infrastructure.Stripe;

public class StripePaymentService : IStripePaymentService
{
    private readonly StripeOptions _options;

    public StripePaymentService(IOptions<StripeOptions> options)
    {
        _options = options.Value;

        if (string.IsNullOrWhiteSpace(_options.SecretKey))
        {
            throw new InvalidOperationException(
                "Stripe SecretKey is not configured.");
        }

        StripeConfiguration.ApiKey = _options.SecretKey;
    }

    public async Task<StripePaymentIntentResult> CreatePaymentIntentAsync(
        long amount,
        string currency,
        string referenceId,
        CancellationToken cancellationToken = default)
    {
        var createOptions = new PaymentIntentCreateOptions
        {
            Amount = amount,
            Currency = currency.ToLowerInvariant(),

            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true
            },

            Metadata = new Dictionary<string, string>
            {
                ["reference_id"] = referenceId
            }
        };

        var service = new PaymentIntentService();

        var paymentIntent = await service.CreateAsync(
            createOptions,
            cancellationToken: cancellationToken);

        return new StripePaymentIntentResult
        {
            PaymentIntentId = paymentIntent.Id,
            ClientSecret = paymentIntent.ClientSecret
        };
    }
}