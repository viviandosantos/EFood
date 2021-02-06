using Products.Infra.Data.Context;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products.Infra.Data.Base
{
    public class DbInitializer
    {
        public static void Initialize(EFoodContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            AddCategories(context);
            AddProducts(context);
            AddSales(context);
            AddPurchases(context);
        }

        private static void AddProducts(EFoodContext context)
        {
            var produtos = new Product[]
            {
                new Product { Name = "Doritos", UnitPrice = 10.0m, CategoryId = 1, Quantity = 10 },
                new Product { Name = "Bis",     UnitPrice = 5.0m,  CategoryId = 2, Quantity = 10 },
                new Product { Name = "Pepsi",   UnitPrice =  8.0m, CategoryId = 3, Quantity = 10 },
            };
            foreach (var p in produtos)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }

        private static void AddCategories(EFoodContext context)
        {
            var categorias = new Category[] {
                new Category { Name = "Salgados" },
                new Category { Name = "Doces" },
                new Category { Name = "Bebidas" },
            };
            foreach (var c in categorias)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
        }

        private static void AddSales(EFoodContext context)
        {
            var items = new ProductSale[]
            {
                new ProductSale { ProductId = 1, Quantity = 1, UnitPrice = 26.0m }
            };

            var sales = new Sale[]
            {
                new Sale { Items = items }
            };

            foreach (var s in sales)
            {
                context.Sales.Add(s);
            }
            context.SaveChanges();
        }

        private static void AddPurchases(EFoodContext context)
        {
            var items = new ProductPurchase[]
            {
                new ProductPurchase { ProductId = 1, Quantity = 10, UnitPrice = 8.0m },
                new ProductPurchase { ProductId = 2, Quantity = 10, UnitPrice = 2.5m },
                new ProductPurchase { ProductId = 3, Quantity = 10, UnitPrice = 6.3m },
            };

            var purchases = new Purchase[]
            {
                new Purchase { Items = items }
            };

            foreach (var p in purchases)
            {
                context.Purchases.Add(p);
            }
            context.SaveChanges();
        }
    }
}
