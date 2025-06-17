using Ecom.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products");
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder
                .Property(p => p.StockQuantity)
                .IsRequired();
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            builder
                .HasMany(p => p.ProductPhotos)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId);
            builder
                .HasData(
                    new Product
                    {
                        Id = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                        Name = "Smartphone",
                        Description = "Latest model smartphone with advanced features.",
                        Price = 699.99m,
                        StockQuantity = 50,
                        CategoryId = Guid.Parse("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432") // Electronics
                    },
                    new Product
                    {
                        Id = Guid.Parse("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                        Name = "Laptop",
                        Description = "High-performance laptop for gaming and work.",
                        Price = 1299.99m,
                        StockQuantity = 30,
                        CategoryId = Guid.Parse("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432") // Electronics
                    },
                    new Product
                    {
                        Id = Guid.Parse("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                        Name = "Office Chair",
                        Description = "Ergonomic office chair with lumbar support.",
                        Price = 199.99m,
                        StockQuantity = 20,
                        CategoryId = Guid.Parse("7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b") // Furniture
                    },
                    new Product
                    {
                        Id = Guid.Parse("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                        Name = "Dining Table",
                        Description = "Modern dining table made of solid wood.",
                        Price = 499.99m,
                        StockQuantity = 10,
                        CategoryId = Guid.Parse("7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b") // Furniture
                    }
                );
        }
    }
}
