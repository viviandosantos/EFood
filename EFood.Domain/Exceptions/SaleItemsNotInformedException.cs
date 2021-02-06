using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Domain.Exceptions
{
    class SaleItemsNotInformedException : Exception
    {
        public SaleItemsNotInformedException() { }
        public SaleItemsNotInformedException(string message) : base (message) { }
    }
}
