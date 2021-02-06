using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Infra.Data.Mappings
{
    class ProductSaleMap : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.ToTable("ProductSale");
            builder.HasKey(ps => new { ps.ProductId, ps.SaleId });

            builder
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductsSales)
                .HasForeignKey(ps => ps.ProductId);

            builder
                .HasOne(ps => ps.Sale)
                .WithMany(p => p.Items)
                .HasForeignKey(ps => ps.SaleId);
        }
    }
}
