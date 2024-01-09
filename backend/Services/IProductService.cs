using backend.Data.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IProductService
    {
        Task<DbProduct> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> AddProductAsync(ProductCreationDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int id);
    }
}
