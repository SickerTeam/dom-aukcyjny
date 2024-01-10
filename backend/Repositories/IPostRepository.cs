using backend.Data.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<DbPost>> GetAllPostsAsync();
        Task<DbPost> GetPostByIdAsync(int id);
        Task<DbPost> CreatePostAsync(DbPost post);
        Task UpdatePostAsync(DbPost post);
        Task DeletePostAsync(DbPost post);       
    }
}
        
