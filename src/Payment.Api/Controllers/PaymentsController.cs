using Microsoft.AspNetCore.Mvc;
using Payment.Abstractions.UseCases;
using Payment.Share.DataTransferObjects.Api.Requests;
using Payment.Share.DataTransferObjects.Api.Responses;
using Payment.Share.DataTransferObjects.Service.Commands;

namespace Payment.Api.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly ICreatePaymentHandler _createPaymentHandler;

    public PaymentsController(ICreatePaymentHandler createPaymentHandler)
    {
        _createPaymentHandler = createPaymentHandler;
    }

    [HttpPost]
    public async Task<ActionResult<CreatePaymentResponse>> Create(
        [FromBody] CreatePaymentRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreatePaymentCommand
        {
            ReferenceId = request.ReferenceId,
            Amount = request.Amount,
            Currency = request.Currency
        };

        var result = await _createPaymentHandler.HandleAsync(
            command,
            cancellationToken);

        var response = new CreatePaymentResponse
        {
            PaymentId = result.PaymentId,
            ClientSecret = result.ClientSecret,
            Status = result.Status
        };

        return Ok(response);
    }
}
