using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task AddPostAsync(PostDTO PostDto);
        Task UpdatePostAsync(PostDTO PostDto);
        Task DeletePostsAsync(int id);
    }
}
