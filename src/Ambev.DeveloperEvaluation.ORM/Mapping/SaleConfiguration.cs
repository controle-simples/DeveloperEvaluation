using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration for the Sale entity using Fluent API.
    /// Defines table name, keys, properties, and relationships.
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            // Primary key
            builder.HasKey(s => s.Id);

            // ID with UUID type and default generation
            builder.Property(s => s.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            // Customer external identifier
            builder.Property(s => s.CustomerExternalId)
                .IsRequired()
                .HasMaxLength(100);

            // Branch external identifier
            builder.Property(s => s.BranchExternalId)
                .IsRequired()
                .HasMaxLength(100);

            // Sale date
            builder.Property(s => s.SaleDate)
                .IsRequired();

            // Cancellation flag
            builder.Property(s => s.Cancelled)
                .IsRequired();

            // One-to-many relationship: Sale → SaleItem
            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey("SaleId") // Shadow property
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}