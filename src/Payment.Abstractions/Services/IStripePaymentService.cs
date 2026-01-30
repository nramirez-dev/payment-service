using Payment.Share.DataTransferObjects.Integrations.Stripe;

namespace Payment.Abstractions;

public interface IStripePaymentService
{
    Task<StripePaymentIntentResult> CreatePaymentIntentAsync(
        long amount,
        string currency,
        string referenceId,
        CancellationToken cancellationToken = default);
}