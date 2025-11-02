using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using DigitalizeFabricationBussiness.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace DigitalizeFabricationBussiness.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<DigitalizeFabricationBusinessDBContext> _contextFactory;

        public ProductRepository(IDbContextFactory<DigitalizeFabricationBusinessDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        
        public async Task<Product> CreateProduct(Product product)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            product.ProductId = Guid.NewGuid().ToString();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(string productId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.FindAsync(productId);
        }

        public IQueryable<Product> GetAllProducts()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Products.AsQueryable();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(string productId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var product = await context.Products.FindAsync(productId);
            
            if (product is null)
            {
                throw new CustomException(HttpStatusCode.NotFound,
                    "Product not found",
                    ErrorCode.PRODUCT_NOT_FOUND);
            }
            
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
