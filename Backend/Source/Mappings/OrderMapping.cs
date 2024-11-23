using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Entities;

namespace Source.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(o => o.Products)
                   .HasColumnType("jsonb");

            builder.Property(o => o.Address)
                   .HasColumnType("jsonb");
        }
    }
}