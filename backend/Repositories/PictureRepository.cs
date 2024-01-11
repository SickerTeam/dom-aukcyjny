using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PictureRepository(DatabaseContext context) : IPictureRepository
    {
        private readonly DatabaseContext _context = context;
        
        public async Task<IEnumerable<DbProductImage>> GetPictureAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<DbProductImage> GetPicturesByIdAsync(int id)
        {
            DbProductImage? picture = await _context.ProductImages.FindAsync(id);
            return picture ?? throw new ArgumentException("Picture not found");            
        }

        public async Task AddPictureAsync(DbProductImage picture)
        {
            _context.ProductImages.Add(picture);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePictureAsync(DbProductImage picture)
        {         
            _context.ProductImages.Remove(picture);
            await _context.SaveChangesAsync();
        }
    }
}
