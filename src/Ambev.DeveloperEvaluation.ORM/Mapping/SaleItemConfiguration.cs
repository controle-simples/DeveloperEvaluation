using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{

    /// <summary>
    /// Configuration for the SaleItem entity using Fluent API
    /// </summary>
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(i => i.ProductExternalId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(i => i.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Foreign key to Sale (shadow property "SaleId")
            builder.Property<Guid>("SaleId")
                .IsRequired();
        }
    }
}
