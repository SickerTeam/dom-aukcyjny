using backend.Models;

namespace backend.Repositories
{
    public interface ILikeRepository
    {
        Task<IList<Like>> GetLikesAsync();
        Task<int> GetAmountOfLikesForPostById(int postId);
        Task<Like> GetLikesByIdAsync(int id);
        Task AddLikesAsync(Like like);
        Task DeleteLikesAsync(int id);
    }
}
