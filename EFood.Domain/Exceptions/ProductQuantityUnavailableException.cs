using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Domain.Exceptions
{
    public class ProductQuantityUnavailableException : Exception
    {
        private string _productName { get; }

        public ProductQuantityUnavailableException() { }
        public ProductQuantityUnavailableException(string message, string productName) : base(message) 
        {
            _productName = productName;
        }

    }
}
