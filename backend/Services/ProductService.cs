using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;

namespace backend.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            IEnumerable<DbProduct> products = await _productRepository.GetAllProductsAsync();
            return  _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<DbProduct> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<ProductDTO> AddProductAsync(ProductCreationDTO productDTO)
        {
            DbProduct dbProduct = new()
            {
                Height = productDTO.Height,
                Width = productDTO.Width,
                Depth = productDTO.Depth,
                Weight = productDTO.Weight,
                ProductImages = _mapper.Map<ICollection<DbProductImage>>(productDTO.ProductImages),
                Title = productDTO.Title,
                Description = productDTO.Description,
                Artist = productDTO.Artist,
                SellerId = productDTO.SellerId,
                CreatedAt = DateTime.UtcNow,
                Year = productDTO.Year
            };
            
            DbProduct product = await _productRepository.CreateProductAsync(dbProduct);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            DbProduct product = await _productRepository.GetProductByIdAsync(productDTO.Id);
            if (product == null) return;

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            DbProduct product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return;

            await _productRepository.DeleteProductAsync(product);
        }
    }
}