using backend.Data.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<DbPost>> GetAllPostsAsync();
        Task<DbPost> GetPostByIdAsync(int id);
        Task<DbPost> CreatePostAsync(PostCreationDTO post);
        Task UpdatePostAsync(DbPost post);
        Task DeletePostAsync(int id);
        // Task<IList<Like>> GetLikesByPostIdAsync(int id);
        // Task<IList<Comment>> GetCommentsByPostIdAsync(int id);
        // Task<IList<Picture>> GetPicturesByPostIdAsync(int id);
        
    }
}
        
