
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
            return await _context.InstaBuys.ToListAsync();
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
            var instaBuy = await _context.InstaBuys.FindAsync(id);
            if (instaBuy == null) return;

            _context.InstaBuys.Remove(instaBuy);
            await _context.SaveChangesAsync();
        }

        public async Task<InstaBuy> GetInstaBuyByIdAsync(int id)
        {
            return await _context.InstaBuys.FindAsync(id);
        }
    }
}
