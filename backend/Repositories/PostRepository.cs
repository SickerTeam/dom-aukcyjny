using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PostRepository(DatabaseContext context) : IPostRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<Post>> GetPostAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var Post = await _context.Posts.FindAsync(id);
            return Post ?? throw new ArgumentException("Post not found");
        }

         public async Task AddPostAsync(Post Post)
        {
            await _context.Posts.AddAsync(Post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post Post)
        {
            _context.Posts.Update(Post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var Post = await _context.Posts.FindAsync(id) ?? throw new ArgumentException("Post not found");
            _context.Posts.Remove(Post);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Like>> GetLikesByPostIdAsync(int postId)
        {
            return await _context.Likes.Where(like => like.PostId == postId).ToListAsync() ?? throw new ArgumentException("Like not found");
        }

        public async Task<IList<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _context.Comments.Where(comment => comment.PostId == postId).ToListAsync() ?? throw new ArgumentException("Comment not found");
        }

        public async Task<IList<Picture>> GetPicturesByPostIdAsync(int postId)
        {
            return await _context.Pictures.Where(picture => picture.PostId == postId).ToListAsync() ?? throw new ArgumentException("Picture not found");
        }

        public async Task DeleteLikeAsync(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePictureAsync(Picture picture)
        {
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
        }
        /*
        public async Task<IList<Auction>> GetAuctionsAsync()
        {
            return await _context.Auctions.Include(auction => auction.Product)
            .ThenInclude(product => product.Artist)
            .ToListAsync();
        }
        */
    }
}
