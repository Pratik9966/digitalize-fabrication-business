using DigitalizeFabricationBussiness.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Services.Interface
{
    public interface IProductService
    {
        Task<ProductOutputDTO> CreateProduct(ProductInputDTO productDto);
        Task<ProductOutputDTO?> GetProductById(string productId);
        IQueryable<Product> GetAllProducts();
        Task<ProductOutputDTO?> UpdateProduct(string productId, ProductInputDTO productDto);
        Task<bool> DeleteProduct(string productId);
    }
}
