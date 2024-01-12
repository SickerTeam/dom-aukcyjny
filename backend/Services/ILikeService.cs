using backend.DTOs;

namespace backend.Services
{
    public interface ILikeService
    {
        Task<IList<LikeDTO>> GetLikesAsync();
        Task<int> GetAmountOfLikesForPostById(int postId);
        Task<LikeDTO> GetLikeByIdAsync(int id);
        Task AddLikeAsync(LikeCreationDTO likeDto);
        Task DeleteLikeAsync(int id);
    }
}
