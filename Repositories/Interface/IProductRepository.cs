using DigitalizeFabricationBussiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalizeFabricationBussiness.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product?> GetProductById(string productId);
        IQueryable<Product> GetAllProducts();
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(string productId);
    }
}
