using backend.Data.Models;

namespace backend.Repositories
{
    public interface ICommentRepository
    {
        Task<IList<DbComment>> GetCommentsAsync();
        Task<int> GetAmountOfCommentsForPostById(int postId);
        Task<DbComment> GetCommentsByIdAsync(int id);
        Task AddCommentsAsync(DbComment comment);
        Task DeleteCommentsAsync(int id);
    }
}
