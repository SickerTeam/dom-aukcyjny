using backend.Data.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IProductRepository
    {
        Task<DbProduct> GetProductByIdAsync(int id);
        Task<IEnumerable<DbProduct>> GetAllProductsAsync();
        Task<DbProduct> CreateProductAsync(DbProduct product);
        Task UpdateProductAsync(DbProduct product);
        Task DeleteProductAsync(int id);
    }

}
