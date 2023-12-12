using backend.Data.Models;

namespace backend.Repositories
{
    public interface ILikeRepository
    {
        Task<IList<DbLike>> GetLikesAsync();
        Task<int> GetAmountOfLikesForPostById(int postId);
        Task<DbLike> GetLikesByIdAsync(int id);
        Task AddLikesAsync(DbLike like);
        Task DeleteLikesAsync(int id);
    }
}
