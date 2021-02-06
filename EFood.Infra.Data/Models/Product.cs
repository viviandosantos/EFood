using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public int Quantity { get; set; }
                
        public Category Category { get; set; }

        public ICollection<ProductPurchase> ProductsPurchases { get; set; }
        public ICollection<ProductSale> ProductsSales { get; set; }
    }
}
