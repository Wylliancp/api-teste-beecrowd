using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(u => u.SaleId).IsRequired();
        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.ProductName).IsRequired();
        builder.Property(u => u.Quantity)
            .IsRequired();
            
        builder.Property(u => u.ValueMonetaryTaxApplied)
            .HasColumnType("decimal(10,2)")
            .IsRequired()
            .HasPrecision(10, 2);
        
        builder.Property(u => u.UnitPrice)
            .HasColumnType("decimal(10,2)")
            .IsRequired()
            .HasPrecision(10, 2);
         
        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion<string>(); // Converte o enum para string no banco de dados
        
        // Configuração do relacionamento com Sale
        builder.HasOne(si => si.Sale) // SaleItem pertence a um Sale
            .WithMany(s => s.Items) // Sale tem muitos SaleItems
            .HasForeignKey(si => si.SaleId) // Chave estrangeira
            .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata
    }
}
