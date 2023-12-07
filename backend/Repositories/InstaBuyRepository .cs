
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
public class InstaBuyRepository(DatabaseContext context) : IInstaBuyRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<IEnumerable<InstaBuy>> GetAllInstaBuysAsync()
        {
            return await _context.InstaBuys.Include(instaBuy => instaBuy.Product)
            .ThenInclude(product => product.Artist)
            .ToListAsync();
        }

        public async Task AddInstaBuyAsync(InstaBuy instaBuy)
        {
            _context.InstaBuys.Add(instaBuy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInstaBuyAsync(InstaBuy instaBuy)
        {
            _context.InstaBuys.Update(instaBuy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInstaBuyAsync(int id)
        {
            var instaBuy = await _context.InstaBuys.FindAsync(id)  ?? throw new ArgumentException("InstaBuy not found");

            _context.InstaBuys.Remove(instaBuy);
            await _context.SaveChangesAsync();
        }

        public async Task<InstaBuy> GetInstaBuyByIdAsync(int id)
        {
            var instaBuy = await _context.InstaBuys.Where(x => x.Id == id)
            .Include(instaBuy => instaBuy.Product)
            .ThenInclude(product => product.Artist)
            .FirstOrDefaultAsync();
            return instaBuy ?? throw new ArgumentException("InstaBuy not found");
        }
    }
}
