using Products.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Domain.Interfaces
{
    public interface IPurchaseBc
    {
        public Task Create(Purchase purchase);
    }
}
