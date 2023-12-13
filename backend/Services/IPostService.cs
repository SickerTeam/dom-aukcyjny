using backend.Data.Models;
using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task<DbPost> CreatePostAsync(PostCreationDTO PostDto);
        Task UpdatePostAsync(PostDTO PostDto);
        Task DeletePostsAsync(int id);
    }
}
