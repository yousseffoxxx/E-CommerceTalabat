namespace Persistence.Data.Configuration
{
    internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(d => d.Price)
                .HasColumnType("decimal(18,3)");

            builder.OwnsOne(item => item.Product,
                product => product.WithOwner());
        }
    }
}
