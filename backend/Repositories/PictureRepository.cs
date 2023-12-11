using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PictureRepository(DatabaseContext context) : IPictureRepository
    {
        private readonly DatabaseContext _context = context;
        public async Task<IList<Picture>> GetPicturesAsync()
        {
            return await _context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetPicturesByIdAsync(int id)
        {
            return await _context.Pictures.FindAsync(id) ?? throw new ArgumentException("Picture not found");
        }

        public async Task AddPicturesAsync(Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePicturesAsync(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture != null)
            {
                _context.Pictures.Remove(picture);
                await _context.SaveChangesAsync();
            }
        }
    }
}
