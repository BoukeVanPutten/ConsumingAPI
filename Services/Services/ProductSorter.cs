using ServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ServiceProject.Services
{
    public class ProductSorter : IProductSorter
    {
        public IOrderedEnumerable<Product> SortProducts(List<Product> products)
        {
            var sortedProducts = products.OrderBy(x => x.Stock);            

            return sortedProducts;
        }
    }
}
