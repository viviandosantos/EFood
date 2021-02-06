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
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly EFoodContext _context;

        public PurchaseRepository(EFoodContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public async Task<Purchase> Get(long id)
        {
            return await _context.Purchases.FindAsync(id);
        }

        public async Task<IEnumerable<Purchase>> Get()
        {
            return await _context.Purchases.Include(p => p.Items).ToListAsync();
        }
    }
}
