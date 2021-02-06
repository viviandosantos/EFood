using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class Sale
    {
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        public ICollection<ProductSale> Items { get; set; }

        public decimal Amount
        {
            get
            {
                return Items != null ? Items.Sum(item => item.Amount) : 0;
            }
        }
    }
}
