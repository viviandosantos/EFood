using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class ProductPurchase
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }


        public long PurchaseId { get; set; }
        public Purchase Purchase { get; set; }


        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Amount {
            get 
            {
                return Quantity * UnitPrice;
            }   
        }


    }
}
