namespace Persistence.Data.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.OwnsOne(order => order.ShippingAddress,
                shippingAddress => shippingAddress.WithOwner());

            builder.HasMany(order => order.OrderItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(order => order.PaymentStatus)
                .HasConversion(s => s.ToString(),
                s => Enum.Parse<OrderPaymentStatus>(s));

            builder.HasOne(order => order.DeliveryMethod)
                .WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(18,3)");
        }
    }
}
