using backend.Models;

namespace backend.Repositories
{
    public interface ICommentRepository
    {
        Task<IList<Comment>> GetCommentsAsync();
        Task<int> GetAmountOfCommentsForPostById(int postId);
        Task<Comment> GetCommentsByIdAsync(int id);
        Task AddCommentsAsync(Comment comment);
        Task DeleteCommentsAsync(int id);
    }
}
