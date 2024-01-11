using backend.DTOs;

namespace backend.Services
{
    public interface IProductImageService
    {
        Task<IList<ProductImageDTO>> GetProductImagesAsync();
        Task<ProductImageDTO> GetProductImageByIdAsync(int id);
        Task AddProductImageAsync(ProductImageCreationDTO commentDto);
        Task DeleteProductImageAsync(int id);
    }
}
