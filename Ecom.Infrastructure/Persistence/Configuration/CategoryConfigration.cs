using Ecom.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Persistence.Configuration
{
    internal class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Categories");
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasData(
                    new Category
                    {
                        Id = Guid.Parse("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432"),
                        Name = "Electronics"
                    },
                    new Category
                    {
                        Id = Guid.Parse("b2f2c2d2-e2f2-4a2b-9c2d-2e2f2a2b2c2d"),
                        Name = "Books"
                    },
                    new Category
                    {
                        Id = Guid.Parse("c3a3d3e3-f3a3-4b3c-0d3e-3f3a3b3c3d3e"),
                        Name = "Clothing"
                    }
                );
        }
    }
}
