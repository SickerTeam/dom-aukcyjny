using backend.Data;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ProductImageRepository(DatabaseContext context) : IProductImageRepository
    {
        private readonly DatabaseContext _context = context;
        
        public async Task<IEnumerable<DbProductImage>> GetProductImageAsync()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<DbProductImage> GetProductImagesByIdAsync(int id)
        {
            DbProductImage? ProductImage = await _context.ProductImages.FindAsync(id);
            return ProductImage ?? throw new ArgumentException("ProductImage not found");            
        }

        public async Task<IEnumerable<DbProductImage>> GetProductImagesByProductIdAsync(int productId)
        {
            var productImages = await _context.ProductImages
                .Where(p => p.ProductId == productId)
                .ToListAsync();
            
            return productImages ?? throw new ArgumentException("ProductImages not found");
        }

        public async Task AddProductImageAsync(DbProductImage ProductImage)
        {
            _context.ProductImages.Add(ProductImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductImageAsync(DbProductImage ProductImage)
        {         
            _context.ProductImages.Remove(ProductImage);
            await _context.SaveChangesAsync();
        }
    }
}
