using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Payment.Infrastructure.Context;

namespace Payment.Infrastructure;

public class PaymentDbContextFactory
    : IDesignTimeDbContextFactory<PaymentDbContext>
{
    public PaymentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PaymentDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=PaymentsDb;User Id=sa;Password=1234;TrustServerCertificate=True;");

        return new PaymentDbContext(optionsBuilder.Options);
    }
}
