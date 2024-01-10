using backend.Data.Models;

namespace backend.Repositories
{
    public interface IPictureRepository
    {
        Task<IEnumerable<DbPicture>> GetPictureAsync();
        Task<DbPicture> GetPicturesByIdAsync(int id);
        Task AddPictureAsync(DbPicture picture);
        Task DeletePictureAsync(DbPicture picture);
    }
}
