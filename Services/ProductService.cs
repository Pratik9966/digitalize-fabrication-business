using AutoMapper;
using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using DigitalizeFabricationBussiness.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using DigitalizeFabricationBussiness.Utilities.Exceptions;

namespace DigitalizeFabricationBussiness.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductOutputDTO> CreateProduct(ProductCreateDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.CreateProduct(product);
            return _mapper.Map<ProductOutputDTO>(createdProduct);
        }

        public async Task<ProductOutputDTO?> GetProductById(string productId)
        {
            var product = await _productRepository.GetProductById(productId);
            return _mapper.Map<ProductOutputDTO>(product);
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public async Task<ProductOutputDTO?> UpdateProduct(string productId, ProductUpdateDTO productDto)
        {
            var product = await _productRepository.GetProductById(productId);
            
            if (product == null)
                throw new CustomException(HttpStatusCode.NotFound,
                    "Product not found",
                    ErrorCode.GENERAL_ERROR);
            
            if (productDto.ProductName != null)
            {
                product.ProductName = productDto.ProductName;
            }

            if (productDto.Description != null)
            {
                product.Description = productDto.Description;
            }

            if (productDto.Price.HasValue)
            {
                product.Price = productDto.Price.Value;
            }

            if (productDto.Category.HasValue)
            {
                product.Category = productDto.Category.Value;
            }

            if (productDto.ProductImages != null && productDto.ProductImages.Any())
            {
                product.ProductImages = productDto.ProductImages;
            }
            
            var updatedProduct = await _productRepository.UpdateProduct(product);
            return _mapper.Map<ProductOutputDTO>(updatedProduct);
        }
        

        public async Task<bool> DeleteProduct(string productId)
        {            
            await _productRepository.DeleteProduct(productId);
            return true;
        }
    }
}
