using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceProject.Services;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IOrderFilter _orderFilter;
        IProductSetter _productSetter;
        IProductSorter _productSorter;
        IAPIClient _apiClient;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderFilter orderFilter, IProductSetter productSetter, IProductSorter productSorter, IAPIClient apiClient)
        {
            _logger = logger;

            _orderFilter = orderFilter;
            _productSetter = productSetter;
            _productSorter = productSorter;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel();

            var orders = await _apiClient.RetrieveOrdersInProgressAsync();
            var filteredProducts = _orderFilter.FilterOrdersToTop5Products(orders);
            var orderedProducts = _productSorter.SortProducts(filteredProducts);

            var product = orderedProducts.First();
            var updatedProduct = _productSetter.SetProductQuantityTo25(product);
            var result = await _apiClient.UpdateProductAsync(updatedProduct);

            vm.ordererdProducts = orderedProducts;
            vm.patchResult = result;

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
