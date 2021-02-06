using EFood.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.Infra.Data.Context;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Infra.Data.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly EFoodContext _context;

        public SaleRepository(EFoodContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public async Task<Sale> Get(long id)
        {
            var sale = await _context.Sales.FindAsync(id);
            _context.Entry(sale)
                .Collection(b => b.Items)
                .Load();
            return sale;
        }

        public async Task<IEnumerable<Sale>> Get()
        {
            return await _context.Sales.Include(s => s.Items).ToListAsync();
        }
    }
}
