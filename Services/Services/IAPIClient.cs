using ServiceProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProject.Services
{
    public interface IAPIClient
    {
        Task<List<OrderModel>> RetrieveOrdersInProgressAsync();
        Task<string> UpdateProductAsync(Product product);
    }
}