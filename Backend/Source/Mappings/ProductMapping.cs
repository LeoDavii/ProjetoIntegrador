using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Entities;

namespace Source.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.ImageUrl)
                   .IsRequired(false);
        }
    }
}