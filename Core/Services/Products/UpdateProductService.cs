using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
       

        void IUpdateProductService.Update(Product product, string name, string description, double price)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetPrice(price);
        }
    }
}