using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Services.Interface;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using HotChocolate;
using Microsoft.AspNetCore.Authorization;

namespace DigitalizedFabricationBusiness.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        [GraphQLName("CreateProduct")]
        [Authorize(Roles = nameof(RolesEnum.ADMIN))]
        public async Task<ProductOutputDTO> CreateProduct([Service] IProductService productService, ProductCreateDTO productInput)
        {
            return await productService.CreateProduct(productInput);
        }

        public async Task<ProductOutputDTO> UpdateProduct([Service] IProductService productService, string productId, ProductUpdateDTO productInput)
        {
            var updatedProduct = await productService.UpdateProduct(productId, productInput);
            if (updatedProduct == null)
            {
                throw new GraphQLException(new Error("Product not found.", "PRODUCT_NOT_FOUND"));
            }
            return updatedProduct;
        }

        public async Task<bool> DeleteProduct([Service] IProductService productService, string productId)
        {
            return await productService.DeleteProduct(productId);
        }
    }
}
