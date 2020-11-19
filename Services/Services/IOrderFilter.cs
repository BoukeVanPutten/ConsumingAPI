using ServiceProject.Models;
using System.Collections.Generic;

namespace ServiceProject.Services
{
    public interface IOrderFilter
    {
        List<Product> FilterOrdersToTop5Products(List<OrderModel> orders);
    }
}