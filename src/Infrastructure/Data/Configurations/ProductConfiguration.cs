using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMaster.Domain.Entities;

namespace ProductMaster.Infrastructure.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.ProductId).UseIdentityColumn().IsRequired();
        builder.HasIndex(p => p.ProductId).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
        builder.Property(p => p.StatusId).IsRequired();
        builder.Property(t => t.Stock).HasPrecision(18);
        builder.Property(p => p.Description).HasMaxLength(300);

        builder.Property(t => t.Price).HasPrecision(18, 2).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(t => t.Discount).HasPrecision(18, 2).HasColumnType("decimal(18,2)");
        builder.Property(t => t.FinalPrice).HasPrecision(18, 2).HasColumnType("decimal(18,2)").IsRequired();
        //relationships
        //builder.HasOne(p => p.Status).WithOne(s =>s.Product).HasForeignKey<Status>("ProductId").OnDelete(DeleteBehavior.Cascade);
    }
}
