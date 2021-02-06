using EFood.Domain.Exceptions;
using EFood.Domain.Interfaces;
using EFood.Infra.Data.Interfaces;
using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Domain
{
    public class SaleBc : ISaleBc
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleBc(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }


        public async Task Create(Sale sale)
        {
            if (sale.Items == null)
                throw new SaleItemsNotInformedException("Cancelled sale: products not informed!");

            foreach (var item in sale.Items)
            {
                var product = await _productRepository.Get(item.ProductId);

                if (product == null)
                    throw new ProductNotFoundException("Cancelled sale: product not found!");

                if (item.Quantity > product.Quantity)
                    throw new ProductQuantityUnavailableException("Cancelled sale: product quantity unavailable!", product.Name);
                else
                    product.Quantity -= item.Quantity;

                _productRepository.Edit(product);
                item.UnitPrice = product.UnitPrice;
            }

            _saleRepository.Create(sale);
        }
    }
}
