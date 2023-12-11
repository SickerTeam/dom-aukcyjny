using backend.Models;

namespace backend.Repositories
{
    public interface IPictureRepository
    {
        Task<IList<Picture>> GetPicturesAsync();
        Task<Picture> GetPicturesByIdAsync(int id);
        Task AddPicturesAsync(Picture picture);
        Task DeletePicturesAsync(int id);
    }
}
