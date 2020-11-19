using Newtonsoft.Json;
using ServiceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ServiceProject.Services
{
    public class APIClient : IAPIClient
    {
        public readonly string _key = "ApiKeyValue541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        public readonly string _apiEndpoint = "https://somefakewebsite.com/api/orders";

        public async Task<List<OrderModel>> RetrieveOrdersInProgressAsync()
        {
            var url = $"{_apiEndpoint}?statuses=IN_PROGRESS";

            using var client = new WebClient();
            client.Headers.Add("X-CE-KEY", _key);

            var data = await client.DownloadStringTaskAsync(url);
            var root = JsonConvert.DeserializeObject<Root>(data);
            var orders = root.Content.Select(x => new OrderModel { Lines = x.Lines }).ToList();

            return orders;
        }

        public async Task<string> UpdateProductAsync(Product product)
        {
            var uri = new Uri($"{_apiEndpoint}" + $"{product.MerchantProductNo}");

            var bodyObject = new List<UpdateModel> { new UpdateModel { Op = "replace", Value = product.Stock, Path = "stock" } };
            var bodyJson = JsonConvert.SerializeObject(bodyObject);

            using var client = new WebClient();
            client.Headers.Add("X-CE-KEY", _key);

            var result = await client.UploadStringTaskAsync(uri, "PATCH", bodyJson);

            return result;
        }
    }
}
