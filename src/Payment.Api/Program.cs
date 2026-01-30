using Payment.Stripe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPaymentServices();
builder.Services.AddPaymentSqlServer(
    builder.Configuration.GetConnectionString("PaymentDatabase")!);
builder.Services.AddStripeInfrastructure(builder.Configuration);


builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


app.MapHealthChecks("/health");

app.Run();