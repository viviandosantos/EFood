using EFood.Domain.Exceptions;
using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Domain
{
    public class ProductBc : IProductBc
    {
        private readonly IProductRepository _productRepository;

        public ProductBc(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<bool> ReadjustPriceByCategory(long categoryId, decimal percent)
        {
            try
            {
                var productsToUpdate = _productRepository.GetByCategory(categoryId).Result.ToList();

                if (productsToUpdate.Any())
                {
                    foreach (var p in productsToUpdate)
                    {
                        p.UnitPrice += (percent / 100) * p.UnitPrice;
                        _productRepository.Edit(p);
                    }

                    return Task.FromResult(true);
                }

                throw new CategoryNotFoundException("Category not found");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
