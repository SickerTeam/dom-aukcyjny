using backend.Data;
using backend.Data.Models;

namespace backend.Repositories
{
    public class PictureRepository(DatabaseContext context) : IPictureRepository
    {
        private readonly DatabaseContext _context = context;
        
        public async Task<IEnumerable<DbPicture>> GetPictureAsync()
        {
            return await _context.Pictures.ToListAsync();
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

        public async Task DeleteCommentsAsync(DbComment comment)
        {         
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<DbPicture>> GetPictureAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DbPicture> GetPicturesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddPictureAsync(DbPicture picture)
        {
            throw new NotImplementedException();
        }

        public Task DeletePictureAsync(DbPicture picture)
        {
            throw new NotImplementedException();
        }
    }
}
