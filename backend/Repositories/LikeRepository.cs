using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class LikeRepository(DatabaseContext context) : ILikeRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IList<DbLike>> GetLikesAsync()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task<int> GetAmountOfLikesForPostById(int postId)
        {
            return await _context.Likes
                .Where(p => p.PostId == postId)
                .CountAsync();
        }

        public async Task<DbLike> GetLikesByIdAsync(int id)
        {
            return await _context.Likes.FindAsync(id) ?? throw new ArgumentException("Like not found");
        }

        public async Task AddLikesAsync(DbLike like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLikesAsync(int id)
        {
            var like = await _context.Likes.FindAsync(id) ?? throw new ArgumentException("Like not found");
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }
}
