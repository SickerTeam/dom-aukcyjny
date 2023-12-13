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
            var likes = await _likeRepository.GetLikesAsync();
            return _mapper.Map<IList<LikeDTO>>(likes);
        }

        public async Task<int> GetAmountOfLikesForPostById(int postId)
        {
            return await _likeRepository.GetAmountOfLikesForPostById(postId);
        }

        public async Task<LikeDTO> GetLikesByIdAsync(int id)
        {
            var like = await _likeRepository.GetLikesByIdAsync(id);
            return _mapper.Map<LikeDTO>(like);
        }

        public async Task AddLikesAsync(LikeCreationDTO likeDto)
        {
            var like = _mapper.Map<DbLike>(likeDto);
            like.CreatedAt = DateTime.Now;
            await _likeRepository.AddLikesAsync(like);
        }

        public async Task DeleteLikesAsync(int id)
        {
            await _likeRepository.DeleteLikesAsync(id);
        }   
    }
}
