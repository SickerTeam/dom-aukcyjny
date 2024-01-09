using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
   public class CommentService(ICommentRepository commentRepository, IMapper mapper) : ICommentService
   {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<CommentDTO>> GetCommentsAsync()
        {
            IEnumerable<DbComment> comments = await _commentRepository.GetCommentsAsync();
            return _mapper.Map<IList<CommentDTO>>(comments);
        }

        public async Task<int> GetAmountOfCommentsForPostById(int postId)
        {
            return await _commentRepository.GetAmountOfCommentsForPostById(postId);
        }

        public async Task<CommentDTO> GetCommentsByIdAsync(int id)
        {
            DbComment comment = await _commentRepository.GetCommentsByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task AddCommentsAsync(CommentCreationDTO commentDto)
        {
            DbComment comment = _mapper.Map<DbComment>(commentDto);
            comment.CreatedAt = DateTime.UtcNow;
            await _commentRepository.AddCommentsAsync(comment);
        }

        public async Task DeleteCommentsAsync(int id)
        {
            DbComment comment = await _commentRepository.GetCommentsByIdAsync(id);
            if (comment == null) return;

            await _commentRepository.DeleteCommentsAsync(comment);
        }
    }
}