using backend.DTOs;

namespace backend.Services
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageDTO>> GetProductImagesAsync();
        Task<ProductImageDTO> GetProductImageByIdAsync(int id);
        Task<IEnumerable<ProductImageDTO>> GetProductImagesByProductIdAsync(int id);
        Task AddProductImageAsync(ProductImageCreationDTO commentDto);
        Task DeleteProductImageAsync(int id);
    }
}
