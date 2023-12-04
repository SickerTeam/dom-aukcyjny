using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Repositories
{
    public class ProductRepository(DatabaseContext context) : IProductRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id) ?? throw new Exception("Product not found");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
