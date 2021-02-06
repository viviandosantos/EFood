using EFood.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Infra.Data.Context
{
    public class EFoodContext : DbContext
    {
        public EFoodContext(DbContextOptions<EFoodContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ProductPurchase> PurchasesItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProductSale> SalesItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductSaleMap());
            modelBuilder.ApplyConfiguration(new ProductPurchaseMap());
            modelBuilder.ApplyConfiguration(new PurchaseMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
        }

    }
}
