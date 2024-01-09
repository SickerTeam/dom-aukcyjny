using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
    public class LikeService(ILikeRepository likeRepository, IMapper mapper) : ILikeService
    {
        private readonly ILikeRepository _likeRepository = likeRepository;
        private readonly IMapper _mapper = mapper;   

        public async Task<IList<LikeDTO>> GetLikesAsync()
        {
            IEnumerable<DbLike> likes = await _likeRepository.GetLikesAsync();
            return _mapper.Map<IList<LikeDTO>>(likes);
        }

        public async Task<int> GetAmountOfLikesForPostById(int postId)
        {
            return await _likeRepository.GetAmountOfLikesForPostById(postId);
        }

        public async Task<LikeDTO> GetLikeByIdAsync(int id)
        {
            DbLike like = await _likeRepository.GetLikeByIdAsync(id);
            return _mapper.Map<LikeDTO>(like);
        }

        public async Task AddLikeAsync(LikeCreationDTO likeDto)
        {
            DbLike like = _mapper.Map<DbLike>(likeDto);
            like.CreatedAt = DateTime.UtcNow;
            await _likeRepository.AddLikeAsync(like);
        }

        public async Task DeleteLikeAsync(int id)
        {
            DbLike like = await _likeRepository.GetLikeByIdAsync(id);
            if (like == null) return;

            await _likeRepository.DeleteLikeAsync(id);
        }   
    }
}
