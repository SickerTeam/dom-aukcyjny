using backend.Data.Models;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<DbPost>> GetPostsAsync();
        Task<DbPost> GetPostByIdAsync(int id);
        Task<int> AddPostAsync(DbPost post);
        Task UpdatePostAsync(DbPost post);
        Task DeletePostAsync(int id);
        // Task<IList<Like>> GetLikesByPostIdAsync(int id);
        // Task<IList<Comment>> GetCommentsByPostIdAsync(int id);
        // Task<IList<Picture>> GetPicturesByPostIdAsync(int id);
        
    }
}
        
