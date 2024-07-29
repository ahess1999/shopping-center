using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingCenter.Data.Entity;

public class Order
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public bool IsShipped { get; set; }

    public Order(int productId, bool isShipped)
    {
        ProductId = productId;
        IsShipped = isShipped;
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.ProductId)
            .IsRequired();

        builder.Property(o => o.IsShipped)
            .IsRequired();

    }
}
