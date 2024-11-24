using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Entities;

namespace Source.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasData(new User("John Customer", "johnC@test.com.br", "test", null, Enum.UserRole.Customer),
                            new User("John Manager", "johnM@test.com.br", "test", null, Enum.UserRole.Manager));

            builder.Property(o => o.Adresses)
                   .HasColumnType("jsonb");
        }
    }
}