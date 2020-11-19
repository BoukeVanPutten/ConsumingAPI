using ServiceProject.Models;

namespace ServiceProject.Services
{
    public interface IProductSetter
    {
        Product SetProductQuantityTo25(Product product);
    }
}