using backend.Data.Models;
using backend.DTOs;

namespace backend.Services
{
    public interface IPostService
    {
        Task<PostDTO> GetPostByIdAsync(int id);
        Task<PostDTO> CreatePostAsync(PostCreationDTO PostDto);
        Task UpdatePostAsync(PostDTO PostDto);
        Task DeletePostsAsync(int id);
    }
}
