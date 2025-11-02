using DigitalizeFabricationBussiness.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Services.Interface
{
    public interface IProductService
    {
        Task<ProductOutputDTO> CreateProduct(ProductCreateDTO productDto);
        Task<ProductOutputDTO?> GetProductById(string productId);
        IQueryable<Product> GetAllProducts();
        Task<ProductOutputDTO?> UpdateProduct(string productId, ProductUpdateDTO productDto);
        Task<bool> DeleteProduct(string productId);
    }
}
