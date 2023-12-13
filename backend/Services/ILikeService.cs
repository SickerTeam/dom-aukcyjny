using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface ILikeService
    {
        Task<IList<LikeDTO>> GetLikesAsync();
        Task<int> GetAmountOfLikesForPostById(int postId);
        Task<LikeDTO> GetLikesByIdAsync(int id);
        Task AddLikesAsync(LikeCreationDTO likeDto);
        Task DeleteLikesAsync(int id);
    }
}






