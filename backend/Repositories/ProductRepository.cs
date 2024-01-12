using backend.Data;
using backend.Data.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;


namespace backend.Repositories
{
    public class ProductRepository(DatabaseContext context, IProductImageRepository productImageRepository) : IProductRepository
    {
        private readonly DatabaseContext _context = context;
        private readonly IProductImageRepository _productImageRepository = productImageRepository;
        
        public async Task<IEnumerable<DbProduct>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Seller)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }

        public async Task<DbProduct> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Where(x => x.Id == id)
                .Include(p => p.Seller)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync() ?? throw new Exception("Product not found");
        }

        public async Task<DbProduct> CreateProductAsync(DbProduct dbProduct)
        {
            _context.Products.Add(dbProduct);
            await _context.SaveChangesAsync();

            return dbProduct;
        }

        public async Task UpdateProductAsync(DbProduct product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(DbProduct product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
