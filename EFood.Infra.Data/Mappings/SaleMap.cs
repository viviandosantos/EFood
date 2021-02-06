using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Infra.Data.Mappings
{
    class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Inserted)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getdate()");
        }
    }
}
