using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }
        public ProductNotFoundException(string message) : base (message){ }
    }
}
