using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class LikeRepository(DatabaseContext context) : ILikeRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IList<Like>> GetLikesAsync()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task<int> GetAmountOfLikesForPostById(int postId)
        {
            return await _context.Likes
                .Where(p => p.PostId == postId)
                .CountAsync();
        }

        public async Task<Like> GetLikesByIdAsync(int id)
        {
            return await _context.Likes.FindAsync(id) ?? throw new ArgumentException("Like not found");
        }

        public async Task AddLikesAsync(Like like)
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
