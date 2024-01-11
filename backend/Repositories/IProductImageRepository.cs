using backend.Data.Models;

namespace backend.Repositories
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<DbProductImage>> GetProductImageAsync();
        Task<DbProductImage> GetProductImagesByIdAsync(int id);
        Task<IEnumerable<DbProductImage>> GetProductImagesByProductIdAsync(int id);
        Task AddProductImageAsync(DbProductImage ProductImage);
        Task DeleteProductImageAsync(DbProductImage ProductImage);
    }
}
