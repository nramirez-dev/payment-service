using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Model.Payment>
{
    public void Configure(EntityTypeBuilder<Model.Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ReferenceId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Amount)
            .IsRequired();

        builder.Property(p => p.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode(false);

        builder.Property(p => p.Status)
            .IsRequired();

        builder.Property(p => p.StripePaymentIntentId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt);
    }
}