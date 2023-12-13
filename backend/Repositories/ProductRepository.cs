using backend.Data;
using backend.Data.Models;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;


namespace backend.Repositories
{
    public class ProductRepository(DatabaseContext context) : IProductRepository
    {
        private readonly DatabaseContext _context = context;

        public async Task<DbProduct> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id) ?? throw new Exception("Product not found");
        }

        public async Task<IEnumerable<DbProduct>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<DbProduct> CreateProductAsync(ProductCreationDTO product)
        {
            var dbProduct = new DbProduct
            {
                Height = product.Height,
                Width = product.Width,
                Depth = product.Depth,
                Weight = product.Weight,
                Title = product.Title,
                Description = product.Description,
                Artist = product.Artist,
                SellerId = 2137,
            };

            _context.Products.Add(dbProduct);
            await _context.SaveChangesAsync();

            return dbProduct;
        }

        public async Task UpdateProductAsync(Product product)
        {
            // _context.Products.Update(product);
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
