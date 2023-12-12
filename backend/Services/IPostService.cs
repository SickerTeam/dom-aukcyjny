using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetPostsAsync();
        Task<PostDTO> GetPostByIdAsync(int id);
        Task AddPostAsync(PostCreationDTO PostDto);
        Task UpdatePostAsync(PostDTO PostDto);
        Task DeletePostsAsync(int id);
    }
}
