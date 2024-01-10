// using backend.Data;
// using backend.Data.Models;

// namespace backend.Repositories
// {
//     public class PictureRepository(DatabaseContext context) : IPictureRepository
//     {
//         private readonly DatabaseContext _context = context;
        
//         public async Task<IEnumerable<DbPicture>> GetPictureAsync()
//         {
//             return await _context.Pictures.ToListAsync();
//         }

//         public async Task<DbPicture> GetPicturesByIdAsync(int id)
//         {
//             DbPicture? picture = await _context.Pictures.FindAsync(id);
//             return picture ?? throw new ArgumentException("Picture not found");            
//         }

//         public async Task AddPictureAsync(DbPicture picture)
//         {
//             _context.Pictures.Add(picture);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeletePictureAsync(DbPicture picture)
//         {         
//             _context.Pictures.Remove(picture);
//             await _context.SaveChangesAsync();
//         }
//     }
// }
