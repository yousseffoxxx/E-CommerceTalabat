using Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
