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
    public class PurchaseBc : IPurchaseBc
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;

        public PurchaseBc(IPurchaseRepository purchaseRepository, IProductRepository productRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }

        public async Task Create(Purchase purchase)
        {
            if (purchase.Items == null)
                throw new PurchaseItemsNotInformedException("Purchase's item not informed!");

            foreach (var item in purchase.Items) 
            {
                var product = await _productRepository.Get(item.ProductId);

                //compra de um produto ainda nao existente na base
                if (product == null && item.Product != null)
                {
                    item.Product.Quantity = item.Quantity;
                    _productRepository.Create(item.Product);
                }
                else 
                {
                    product.Quantity += item.Quantity;
                    _productRepository.Edit(product);
                }

                if (product == null && item.Product == null)
                    throw new ProductNotFoundException();
            }

            _purchaseRepository.Create(purchase);
        }
    }
}
