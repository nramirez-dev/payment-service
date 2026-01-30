using Payment.Share.DataTransferObjects.Service.Commands;
using Payment.Share.DataTransferObjects.Service.Results;

namespace Payment.Abstractions.UseCases;

public interface ICreatePaymentHandler
{
    Task<CreatePaymentResult> HandleAsync(
        CreatePaymentCommand command,
        CancellationToken cancellationToken = default);
}