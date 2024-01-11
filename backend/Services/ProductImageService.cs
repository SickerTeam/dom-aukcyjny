using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
   public class ProductImageService(IProductImageRepository ProductImageRepository, IMapper mapper) : IProductImageService
   {
        private readonly IProductImageRepository _ProductImageRepository = ProductImageRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<ProductImageDTO>> GetProductImagesAsync()
        {
            IEnumerable<DbProductImage> ProductImages = await _ProductImageRepository.GetProductImageAsync();
            return _mapper.Map<IList<ProductImageDTO>>(ProductImages);
        }

        public async Task<ProductImageDTO> GetProductImageByIdAsync(int id)
        {
            DbProductImage ProductImage = await _ProductImageRepository.GetProductImagesByIdAsync(id);
            return _mapper.Map<ProductImageDTO>(ProductImage);
        }

        public async Task AddProductImageAsync(ProductImageCreationDTO commentDto)
        {
            DbProductImage ProductImage = _mapper.Map<DbProductImage>(commentDto);
            ProductImage.CreatedAt = DateTime.UtcNow;
            await _ProductImageRepository.AddProductImageAsync(ProductImage);
        }

        public async Task DeleteProductImageAsync(int id)
        {
            DbProductImage ProductImage = await _ProductImageRepository.GetProductImagesByIdAsync(id);
            if (ProductImage == null) return;

            await _ProductImageRepository.DeleteProductImageAsync(ProductImage);
        }
    }
}