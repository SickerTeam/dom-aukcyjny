using backend.DTOs;

namespace backend.Services
{
    public interface ICommentService
    {
        Task<IList<CommentDTO>> GetCommentsAsync();
        Task<int> GetAmountOfCommentsForPostById(int postId);
        Task<CommentDTO> GetCommentsByIdAsync(int id);
        Task AddCommentsAsync(CommentRegistrationDTO commentDto);
        Task DeleteCommentsAsync(int id);
    }
}
