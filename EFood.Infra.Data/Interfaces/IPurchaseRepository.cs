using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Infra.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        public void Create(Purchase purchase);
        public Task<Purchase> Get(long id);
        public Task<IEnumerable<Purchase>> Get();
    }
}
