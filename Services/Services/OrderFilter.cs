using ServiceProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceProject.Services
{
    public class OrderFilter : IOrderFilter
    {
        public List<Product> FilterOrdersToTop5Products(List<OrderModel> orders)
        {
            var productsTally = new Dictionary<Product, int>();
            var allLines = new List<Line>();

            foreach (var order in orders)
            {
                foreach (var line in order.Lines)
                {
                    allLines.Add(line);
                }
            }

            var allProducts = allLines.Select(x => new Product { Description = x.Description, Gtin = x.Gtin, MerchantProductNo = x.MerchantProductNo, Stock = x.Quantity });
            var filteredProducts = new List<Product>();

            foreach (var product in allProducts)
            {
                if (filteredProducts.Any(x => x.Gtin == product.Gtin))
                {
                    var productToUpdate = filteredProducts.First(x => x.Gtin == product.Gtin);
                    productToUpdate.Stock += product.Stock;
                }
                else
                {
                    filteredProducts.Add(product);
                }
            }

            var sorted = filteredProducts.OrderByDescending(x => x.Stock);
            var highest = sorted.Take(5).ToList();

            return highest;
        }
    }
}
