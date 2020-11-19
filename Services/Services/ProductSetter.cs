using ServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProject.Services
{
    public class ProductSetter : IProductSetter
    {
        public Product SetProductQuantityTo25(Product product)
        {
            product.Stock = 25;
            return product;
        }
    }
}
