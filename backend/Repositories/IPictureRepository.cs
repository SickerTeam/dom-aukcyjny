using backend.Data.Models;

namespace backend.Repositories
{
    public interface IPictureRepository
    {
        Task<IEnumerable<DbProductImage>> GetPictureAsync();
        Task<DbProductImage> GetPicturesByIdAsync(int id);
        Task AddPictureAsync(DbProductImage picture);
        Task DeletePictureAsync(DbProductImage picture);
    }
}
