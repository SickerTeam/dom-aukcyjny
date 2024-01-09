using backend.Data.Models;
using backend.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public interface IPostService
    {
        Task<PostDTO> GetPostByIdAsync(int id);
        Task<PostDTO> CreatePostAsync(PostCreationDTO PostDto);
        Task<PostDTO?> UpdatePostAsync(int id, JsonPatchDocument<PostDTO> patchDoc);
        Task DeletePostsAsync(int id);
    }
}
