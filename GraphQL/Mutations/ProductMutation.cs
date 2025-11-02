using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Services.Interface;
using System.Threading.Tasks;

namespace DigitalizedFabricationBusiness.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        public async Task<ProductOutputDTO> CreateProduct([Service] IProductService productService, ProductInputDTO productInput)
        {
            return await productService.CreateProduct(productInput);
        }

        public async Task<ProductOutputDTO> UpdateProduct([Service] IProductService productService, string productId, ProductInputDTO productInput)
        {
            return await productService.UpdateProduct(productId, productInput);
        }

        public async Task<bool> DeleteProduct([Service] IProductService productService, string productId)
        {
            return await productService.DeleteProduct(productId);
        }
    }
}
