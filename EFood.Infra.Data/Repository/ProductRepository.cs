using EFood.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.Infra.Data.Context;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFoodContext _context;

        public ProductRepository(EFoodContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Product product) 
        {
             _context.Products.Add(product);
            _context.SaveChanges();
        }

        public async Task<Product> Get(long id) 
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> Get() 
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(long categoryId) 
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public void Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

        }

        public async Task Delete(long id) 
        {
            var itemToRemove = await _context.Products.FindAsync(id);

            if (itemToRemove != null)
            {
                _context.Products.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }

        public Task<IEnumerable<Product>> GenerateReport(DateTime? minDate, DateTime? maxDate)
        {
            if (!maxDate.HasValue)
                maxDate = DateTime.Now;

            if (!minDate.HasValue)
                minDate = maxDate.Value.AddDays(-30);

            var query = (from p in _context.Products
                         from pp in p.ProductsPurchases
                         from ps in p.ProductsSales
                         where (pp.Purchase.Inserted >= minDate && pp.Purchase.Inserted < maxDate) || 
                                (ps.Sale.Inserted >= minDate && ps.Sale.Inserted < maxDate)
                         select p);

            query = query.Include(p => p.ProductsPurchases);
            query = query.Include(p => p.ProductsSales);

            return Task.FromResult(query.AsEnumerable());
        }
    }
}
