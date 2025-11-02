using AutoMapper;
using DigitalizeFabricationBussiness.DTOs;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using DigitalizeFabricationBussiness.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ProductOutputDTO> CreateProduct(ProductInputDTO productDto)
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

        public async Task<ProductOutputDTO?> UpdateProduct(string productId, ProductInputDTO productDto)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null) return null;
            _mapper.Map(productDto, product);
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
