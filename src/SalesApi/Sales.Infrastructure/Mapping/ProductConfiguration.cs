using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Category).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).IsRequired().HasMaxLength(150);
        builder.Property(u => u.ImageFile);
        builder.Property(u => u.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired()
            .HasPrecision(10, 2);
        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasConversion(
                v => v.ToUniversalTime(), // Converter para UTC ao salvar
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));// Converter para UTC ao carregar

        builder.Property(u => u.UpdatedAt)
            .HasConversion(
                v => v.HasValue ? v.Value.ToUniversalTime() : (DateTime?)null, // Converter para UTC ao salvar
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : (DateTime?)null); // Converter para UTC ao carregar
    }
}
