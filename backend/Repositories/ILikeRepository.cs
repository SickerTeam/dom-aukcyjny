using backend.Data.Models;

namespace backend.Repositories
{
    public interface ILikeRepository
    {
        Task<IEnumerable<DbLike>> GetLikesAsync();
        Task<int> GetAmountOfLikesForPostById(int postId);
        Task<DbLike> GetLikeByIdAsync(int id);
        Task AddLikeAsync(DbLike like);
        Task DeleteLikeAsync(DbLike like);
    }
}
