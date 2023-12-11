using backend.Models;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<int> AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        // Task<IList<Like>> GetLikesByPostIdAsync(int id);
        // Task<IList<Comment>> GetCommentsByPostIdAsync(int id);
        // Task<IList<Picture>> GetPicturesByPostIdAsync(int id);
        
    }
}
        
