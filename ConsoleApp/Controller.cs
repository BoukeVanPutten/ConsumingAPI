using ServiceProject.Models;
using ServiceProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Controller : IController
    {
        IAPIClient _apiClient;
        IProductSetter _productSetter;
        IProductSorter _productSorter;
        IOrderFilter _orderFilter;

        public Controller(IAPIClient apiClient, IProductSetter productSetter, IOrderFilter orderFilter, IProductSorter productSorter)
        {
            _apiClient = apiClient;
            _productSetter = productSetter;
            _productSorter = productSorter;
            _orderFilter = orderFilter;
        }

        public async Task Run()
        {
            var orders = await _apiClient.RetrieveOrdersInProgressAsync();
            var filteredProducts = _orderFilter.FilterOrdersToTop5Products(orders);
            var orderedProducts = _productSorter.SortProducts(filteredProducts);
            ReportTop5Products(orderedProducts);

            var product = orderedProducts.First();
            var updatedProduct = _productSetter.SetProductQuantityTo25(product);
            var result = await _apiClient.UpdateProductAsync(updatedProduct);
            ReportUpdatingProduct(result);

            Console.ReadKey();
        }

        private void ReportTop5Products(IOrderedEnumerable<Product> orderedProducts)
        {
            foreach (var item in orderedProducts)
            {
                Console.WriteLine($" EAN (etc): {item.Gtin}, Description: {item.Description}, Quantity: {item.Stock}"); // Item name?, EAN/Gtin or Description? not sure, ask when sending in")
            }
        }

        private void ReportUpdatingProduct(string result)
        {
            Console.WriteLine($"Result from updating the product on the API: {result}");
        }
    }
}
