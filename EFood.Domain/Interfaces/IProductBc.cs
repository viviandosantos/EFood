using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Domain.Interfaces
{
    public interface IProductBc
    {
        public Task<bool> ReadjustPriceByCategory(long categoryId, decimal percent);
    }
}
