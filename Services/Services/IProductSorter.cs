using ServiceProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject.Services
{
    public interface IProductSorter
    {
        IOrderedEnumerable<Product> SortProducts(List<Product> products);
    }
}