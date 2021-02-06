using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Infra.Data.Interfaces
{
    public interface ISaleRepository
    {
        public void Create(Sale sale);

        public Task<Sale> Get(long id);

        public Task<IEnumerable<Sale>> Get();

    }
}
