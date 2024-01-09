using backend.Data;
using backend.Data.Models;
using backend.Enums;
using backend.Repositories;
using Xunit;

namespace Testing.Validation
{
    public class AuctionRepositoryTests(DatabaseContext context, IAuctionRepository auctionRepository) : IDisposable
    {
        private readonly DatabaseContext _context = context;
        private readonly IAuctionRepository _auctionRepository = auctionRepository;

        private DbAuction _dbAuction;
        private DbProduct _dbProduct;
        private DbUser _dbUser;

        private void SeedDatabaseWithTestData(DatabaseContext _context)
        {
            _dbUser = new ()
            {
                Id = 1,
                Bio = "Bardzo fajny seller",
                Email = "seller@gmail.com",
                Country = "Poland",
                FirstName = "First name",
                LastName = "Last name",
                PersonalLink = "www.google.com",
                ProfilePictureLink = "www.google.com",
                Role = UserRole.User
            };

            _dbProduct = new ()
            {
                Artist = "Da Vinky?",
                Height = 1,
                Width = 1,
                Depth = 1,
                Weight = 1,
                Description = "Oil painting",
                Id = 1,
                Seller = _dbUser,
                SellerId = 1,
                Title = "Flowers",
                Year = 1989
            };

            _dbAuction = new ()
            {
                Id = 1,
                ProductId = 1,
                CreatedAt = DateTime.UtcNow,
                EndsAt = DateTime.UtcNow,
                EstimateMaxPrice = 0.01,
                EstimateMinPrice = 0.01,
                ReservePrice = 0.01,
                StartingPrice = 0.01,
                IsArchived = false,
                Product = _dbProduct
            };
            DbAuction testAuction = new()
            {

            };
            _context.Auctions.Add(testAuction);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAuctionsAsync_ShouldReturnAuctions()
        {
            // Act
            var auctions = await _auctionRepository.GetAuctionsAsync();

            // Assert
            Assert.NotNull(auctions);
            Assert.NotEmpty(auctions);
        }

        [Fact]
        public async Task GetAuctionByIdAsync_ShouldReturnAuction_WhenAuctionExists()
        {
            // Arrange
            var testAuctionId = 1; // Use an ID that exists in the test data

            // Act
            var auction = await _auctionRepository.GetAuctionByIdAsync(testAuctionId);

            // Assert
            Assert.NotNull(auction);
            Assert.Equal(testAuctionId, auction.Id);
        }

        // Additional tests for CreateAuctionAsync, UpdateAuctionAsync, DeleteAuctionAsync...

        public void Dispose()
        {
            // Clean up the database after tests
            _context.Database.EnsureDeleted();
            _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
