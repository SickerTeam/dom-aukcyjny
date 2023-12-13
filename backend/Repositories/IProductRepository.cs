using backend.Models;
using backend.Data.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IProductRepository
    {
        Task<DbProduct> GetProductByIdAsync(int id);
        Task<IEnumerable<DbProduct>> GetAllProductsAsync();
        Task<DbProduct> CreateProductAsync(ProductCreationDTO product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }

}
