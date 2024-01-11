
// using backend.Data;
// using backend.Data.Models;
// using backend.Enums;
// using backend.Repositories;
// using Microsoft.EntityFrameworkCore;

// namespace Testing.Repositories;

// public class AuctionRepositoryFixture : IDisposable
// {
//     public DatabaseContext Context { get; private set; }
//     public IAuctionRepository AuctionRepository { get; private set; }

//     public AuctionRepositoryFixture()
//     {
//         // Set up the DatabaseContext and AuctionRepository
//         var options = new DbContextOptionsBuilder<DatabaseContext>()
//             .UseSqlServer("Server=hildur.ucn.dk; Database=CSC-CSD-S211_10407553;User Id=CSC-CSD-S211_10407553; Password=Password1!;")
//             .Options;
//         Context = new DatabaseContext(options);
//         AuctionRepository = new AuctionRepository(Context);

//         // Ensure the database is created and seed it with test data
//         Context.Database.EnsureCreated();
//         SeedDatabaseWithTestData();
//     }

//     private void SeedDatabaseWithTestData()
//     {
//             DbUser _dbUser = new ()
//             {
//                 Id = 1,
//                 Bio = "Bardzo fajny seller",
//                 Email = "seller@gmail.com",
//                 Country = "Poland",
//                 FirstName = "First name",
//                 LastName = "Last name",
//                 PersonalLink = "www.google.com",
//                 ProfilePictureLink = "www.google.com",
//                 Role = UserRole.User
//             };

//             DbProduct _dbProduct = new ()
//             {
//                 Artist = "Da Vinky?",
//                 Height = 1,
//                 Width = 1,
//                 Depth = 1,
//                 Weight = 1,
//                 Description = "Oil painting",
//                 Id = 1,
//                 Seller = _dbUser,
//                 SellerId = 1,
//                 Title = "Flowers",
//                 Year = 1989
//             };

//             DbAuction _dbAuction = new ()
//             {
//                 Id = 1,
//                 ProductId = 1,
//                 CreatedAt = DateTime.UtcNow,
//                 EndsAt = DateTime.UtcNow,
//                 EstimateMaxPrice = 0.01,
//                 EstimateMinPrice = 0.01,
//                 ReservePrice = 0.01,
//                 StartingPrice = 0.01,
//                 IsArchived = false,
//                 Product = _dbProduct
//             };
//             Context.Auctions.Add(_dbAuction);
//             Context.SaveChanges();
//     }

//     public void Dispose()
//     {
//         // Clean up the database after tests
//         Context.Database.EnsureDeleted();
//         Context.Dispose();

//        GC.SuppressFinalize(this);
//     }
// }