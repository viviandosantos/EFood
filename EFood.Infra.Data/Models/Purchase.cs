using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class Purchase
    {
        public long Id { get; set; }

        public DateTime Inserted { get; set; }

        public ICollection<ProductPurchase> Items { get; set; }

        public decimal Amount
        {
            get
            {
                return Items != null ? Items.Sum(item => item.Amount) : 0;
            }
        }
    }
}
