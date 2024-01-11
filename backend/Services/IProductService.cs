using backend.DTOs;

namespace backend.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> AddProductAsync(ProductCreationDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int id);
    }
}
