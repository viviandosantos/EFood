using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Infra.Data.Interfaces
{
    public interface IProductRepository
    {
        public void Create(Product product);
        public void Edit(Product product);
        public Task<Product> Get(long id);
        public Task<IEnumerable<Product>> Get();
        public Task<IEnumerable<Product>> GetByCategory(long categoryId);
        public Task Delete(long id);
        public Task<IEnumerable<Product>> GenerateReport(DateTime? minDate, DateTime? maxDate);
    }
}
