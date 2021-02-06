using System;
using System.Collections.Generic;
using System.Text;

namespace EFood.Domain.Exceptions
{
    public class PurchaseItemsNotInformedException : Exception
    {
        public PurchaseItemsNotInformedException() { }
        public PurchaseItemsNotInformedException(string message) : base (message) { }
    }
}
