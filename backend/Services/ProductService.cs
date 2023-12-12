using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<DbProduct> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<DbProduct>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task AddProductAsync(ProductCreationDTO productDTO)
        {
            var product = _mapper.Map<ProductCreationDTO>(productDTO);
            await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }

}
