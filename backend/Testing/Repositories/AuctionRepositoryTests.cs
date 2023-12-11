// using Xunit;
// using Microsoft.EntityFrameworkCore;
// using backend.Data;
// using backend.Models;
// using backend.Repositories;

// namespace backend.Tests
// {
//    public class AuctionRepositoryTests
//    {
//        private readonly DatabaseContext _context;
//        private readonly AuctionRepository _auctionRepository;

//        public AuctionRepositoryTests()
//        {
//            var options = new DbContextOptionsBuilder<DatabaseContext>()
//                .UseSqlServer("YourTestDatabaseConnectionString")
//                .Options;

//            _context = new DatabaseContext(options);
//            _auctionRepository = new AuctionRepository(_context);
//        }

//        [Fact]
//        public async Task GetAuctionsAsync_ReturnsAuctions()
//        {
//            // Arrange
//            var expectedAuctions = new List<Auction>
//            {
//                new() { 
//                   Id = 1, 
//                   EndsAt = DateTime.Now, 
//                   FirstPrice = 100.0m, 
//                   Product = new(){
//                     Depth = 0,
//                     Height = 0,
//                     Weight = 0,
//                     Width = 0,
//                     Description = "Very nice",
//                     Id = 69,
//                     Title = "plesnivy_kokot_oil_2016",
//                     Artist = new() {
//                         Bio = "Performance artist based in Poland",
//                         Country = "PL",
//                         Email = "domaukcijny@gmail.com",
//                         FirstName = "Gabi",
//                         LastName = "Zabi Las Vegas",
//                         Id = 420,
//                         Password = "Password exposed in front of underages bois",
//                         PersonalLink = "linkedin.dk/gabizabimiami"
//                     }
//                   }, 
//                   EstimatedMinimum = 50.0m, 
//                   EstimatedMaximum = 200.0m, 
//                   IsArchived = false, 
//                   CreatedAt = DateTime.Now 
//                },
//                new() { 
//                   Id = 2, 
//                   EndsAt = DateTime.Now, 
//                   FirstPrice = 200.0m, 
//                   ProductId = 2, 
//                   EstimatedMinimum = 100.0m, 
//                   EstimatedMaximum = 300.0m, 
//                   IsArchived = false, 
//                   CreatedAt = DateTime.Now 
//                }
//            };

//            // Act
//            var auctions = await _auctionRepository.GetAuctionsAsync();

//            // Assert
//            Assert.Equal(expectedAuctions, auctions);
//        }

//        [Fact]
//        public async Task GetAuctionByIdAsync_ReturnsAuction()
//        {
//            // Arrange
//            var expectedAuction = new Auction 
//            { 
//                Id = 1, 
//                EndsAt = DateTime.Now, 
//                FirstPrice = 100.0m, 
//                ProductId = 1, 
//                EstimatedMinimum = 50.0m, 
//                EstimatedMaximum = 200.0m, 
//                IsArchived = false, 
//                CreatedAt = DateTime.Now 
//            };

//            // Act
//            var auction = await _auctionRepository.GetAuctionByIdAsync(1);

//            // Assert
//            Assert.Equal(expectedAuction, auction);
//        }
//    }
// }

//////////////////////// chatbot ///////////////////////////////

//  public class AuctionRepositoryTests
//  {
//      private readonly DatabaseContext _context;
//      private readonly AuctionRepository _auctionRepository;

//      public AuctionRepositoryTests()
//      {
//          var options = new DbContextOptionsBuilder<DatabaseContext>()
//              .UseInMemoryDatabase("TestDatabase")
//              .Options;

//          _context = new DatabaseContext(options);
//          _auctionRepository = new AuctionRepository(_context);
//      }

//      [Fact]
//      public async Task GetAuctionsAsync_ReturnsAuctions()
//      {
//          // Arrange
//          var artist = new User
//          {
//              Bio = "Performance artist based in Poland",
//              Country = "PL",
//              Email = "domaukcijny@gmail.com",
//              FirstName = "Gabi",
//              LastName = "Zabi Las Vegas",
//              Id = 420,
//              Password = "Password exposed in front of underages bois",
//              PersonalLink = "linkedin.dk/gabizabimiami"
//          };

//          var product = new Product
//          {
//              Depth = 0,
//              Height = 0,
//              Weight = 0,
//              Width = 0,
//              Description = "Very nice",
//              Id = 69,
//              Title = "plesnivy_kokot_oil_2016",
//              Artist = artist
//          };

//          var expectedAuctions = new List<Auction>
//          {
//              new() { 
//                Id = 1, 
//                EndsAt = new DateTime(2023, 12, 4), 
//                FirstPrice = 100.0m, 
//                Product = product,
//                EstimatedMinimum = 50.0m, 
//                EstimatedMaximum = 200.0m, 
//                IsArchived = false, 
//                CreatedAt = new DateTime(2023, 12, 4) 
//              },
//              new() { 
//                Id = 2, 
//                EndsAt = new DateTime(2023, 12, 4), 
//                FirstPrice = 200.0m, 
//                Product = new Product
//                {
//                   Depth = 0,
//                   Height = 0,
//                   Weight = 0,
//                   Width = 0,
//                   Description = "Very nice",
//                   Id = 70,
//                   Title = "plesnivy_kokot_oil_2017",
//                   Artist = artist
//                },
//                EstimatedMinimum = 100.0m, 
//                EstimatedMaximum = 300.0m, 
//                IsArchived = false, 
//                CreatedAt = new DateTime(2023, 12, 4) 
//              }
//          };

//          _context.Users.Add(artist);
//          _context.Products.Add(product);
//          _context.Auctions.AddRange(expectedAuctions);
//          await _context.SaveChangesAsync();

//          // Act
//          var auctions = await _auctionRepository.GetAuctionsAsync();

//          // Assert
//          Assert.Equal(expectedAuctions, auctions);
//      }

//      [Fact]
//      public async Task GetAuctionByIdAsync_ReturnsAuction()
//      {
//          // Arrange
//          var artist = new User
//          {
//              Bio = "Performance artist based in Poland",
//              Country = "PL",
//              Email = "domaukcijny@gmail.com",
//              FirstName = "Gabi",
//              LastName = "Zabi Las Vegas",
//              Id = 420,
//              Password = "Password exposed in front of underages bois",
//              PersonalLink = "linkedin.dk/gabizabimiami"
//          };

//          var product = new Product
//          {
//              Depth = 0,
//              Height = 0,
//              Weight = 0,
//              Width = 0,
//              Description = "Very nice",
//              Id = 69,
//              Title = "plesnivy_kokot_oil_2016",
//              Artist = artist
//          };

//          var expectedAuction = new Auction 
//          { 
//              Id = 1, 
//              EndsAt = new DateTime(2023, 12, 4), 
//              FirstPrice = 100.0m, 
//              Product = product,
//              EstimatedMinimum = 50.0m, 
//              EstimatedMaximum = 200.0m, 
//              IsArchived = false, 
//              CreatedAt = new DateTime(2023, 12, 4) 
//          };

//          _context.Users.Add(artist);
//          _context.Products.Add(product);
//          _context.Auctions.Add(expectedAuction);
//          await _context.SaveChangesAsync();

//          // Act
//          var auction = await _auctionRepository.GetAuctionByIdAsync(1);

//          // Assert
//          Assert.Equal(expectedAuction, auction);
//      }
//  }
// }




