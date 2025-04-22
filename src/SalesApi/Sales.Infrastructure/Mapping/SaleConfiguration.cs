using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(u => u.SaleNumber).IsRequired().HasMaxLength(30);
        builder.Property(u => u.CustomerId).IsRequired();
        builder.Property(u => u.BranchId).IsRequired();
         builder.Property(u => u.SaleDate)
            .IsRequired()
            .HasConversion(
                v => v.ToUniversalTime(), // Converter para UTC ao salvar
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); // Converter para UTC ao carregar
         
        builder.Property(s => s.Status)
             .IsRequired()
             .HasConversion<string>(); // Converte o enum para string no banco de dados
         
        builder.HasMany(s => s.Items)
            .WithOne(p => p.Sale)
            .HasForeignKey(j => j.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
