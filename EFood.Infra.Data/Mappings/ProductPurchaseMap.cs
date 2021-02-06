using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Infra.Data.Mappings
{
    class ProductPurchaseMap : IEntityTypeConfiguration<ProductPurchase>
    {
        public void Configure(EntityTypeBuilder<ProductPurchase> builder)
        {
            builder.ToTable("ProductPurchase");
            builder.HasKey(ps => new { ps.ProductId, ps.PurchaseId });

            builder
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductsPurchases)
                .HasForeignKey(ps => ps.ProductId);

            builder
                .HasOne(ps => ps.Purchase)
                .WithMany(p => p.Items)
                .HasForeignKey(ps => ps.PurchaseId);
        }
    }
}
