using backend.Data.Models;
using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IProductService
    {
        Task<DbProduct> GetProductByIdAsync(int id);
        Task<IEnumerable<DbProduct>> GetAllProductsAsync();
        Task AddProductAsync(ProductCreationDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int id);
    }
}
