using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Infra.Data.Mappings
{
    class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Inserted)
                .HasDefaultValueSql("getdate()");
        }
    }
}
