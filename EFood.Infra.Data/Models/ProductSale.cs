using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class ProductSale
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long SaleId { get; set; }
        public Sale Sale { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        
        [Required]
        public decimal Amount
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
