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

            builder.HasData(
                new Product(12.55, "Cupcake Baunilha", "Cupcake confeitado de baunilha", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20baunilha.png"),
                new Product(14.55, "Cupcake Chocolate", "Delicioso cupcake de chocolate 70%", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20chocolate.jpeg"),
                new Product(15.55, "Cupcake Morango", "Cupcake confeitado de Morango", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20morango.png")
            );
        }
    }
}