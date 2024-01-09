using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CommentRepository(DatabaseContext context) : ICommentRepository
    {
        private readonly DatabaseContext _context = context;
        
        public async Task<IEnumerable<DbComment>> GetCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<int> GetAmountOfCommentsForPostById(int postId)
        {
            return await _context.Comments
                .Where(p => p.PostId == postId)
                .CountAsync();
        }

        public async Task<DbComment> GetCommentsByIdAsync(int id)
        {
            DbComment? comment = await _context.Comments.FindAsync(id);
            return comment ?? throw new ArgumentException("Comment not found");            
        }

        public async Task AddCommentsAsync(DbComment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentsAsync(int id)
        {
            DbComment? comment = await _context.Comments.FindAsync(id);
            if (comment == null) return;
            
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
