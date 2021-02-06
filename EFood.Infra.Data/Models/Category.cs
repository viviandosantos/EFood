using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Products.Infra.Data.Models
{
    public class Category
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
