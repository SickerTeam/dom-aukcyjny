using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PostRepository(DatabaseContext context) : IPostRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<DbPost>> GetAllPostsAsync()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .ToListAsync();
        }

        public async Task<DbPost> GetPostByIdAsync(int id)
        {
            DbPost post = await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new ArgumentException("Post not found");
            return post;
        }

        public async Task<DbPost> CreatePostAsync(DbPost dbPost)
        {
            await _context.Posts.AddAsync(dbPost);
            await _context.SaveChangesAsync();
            
            return dbPost;
        }

        public async Task UpdatePostAsync(DbPost Post)
        {
            _context.Posts.Update(Post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(DbPost post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
