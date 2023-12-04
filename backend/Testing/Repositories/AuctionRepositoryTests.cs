using Xunit;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.Repositories;

namespace backend.Tests
{
   public class AuctionRepositoryTests
   {
       private readonly BackupDatabaseContext _context;
       private readonly AuctionRepository _auctionRepository;

       public AuctionRepositoryTests()
       {
           var options = new DbContextOptionsBuilder<BackupDatabaseContext>()
               .UseSqlServer("YourTestDatabaseConnectionString")
               .Options;

           _context = new BackupDatabaseContext(options);
           _auctionRepository = new AuctionRepository(_context);
       }

       [Fact]
       public async Task GetAuctionsAsync_ReturnsAuctions()
       {
           // Arrange
           var expectedAuctions = new List<Auction>
           {
               new() { 
                  Id = 1, 
                  EndsAt = DateTime.Now, 
                  FirstPrice = 100.0m, 
                  ProductId = 1, 
                  EstimatedMinimum = 50.0m, 
                  EstimatedMaximum = 200.0m, 
                  IsArchived = false, 
                  CreatedAt = DateTime.Now 
               },
               new() { 
                  Id = 2, 
                  EndsAt = DateTime.Now, 
                  FirstPrice = 200.0m, 
                  ProductId = 2, 
                  EstimatedMinimum = 100.0m, 
                  EstimatedMaximum = 300.0m, 
                  IsArchived = false, 
                  CreatedAt = DateTime.Now 
               }
           };

           // Act
           var auctions = await _auctionRepository.GetAuctionsAsync();

           // Assert
           Assert.Equal(expectedAuctions, auctions);
       }

       [Fact]
       public async Task GetAuctionByIdAsync_ReturnsAuction()
       {
           // Arrange
           var expectedAuction = new Auction 
           { 
               Id = 1, 
               EndsAt = DateTime.Now, 
               FirstPrice = 100.0m, 
               ProductId = 1, 
               EstimatedMinimum = 50.0m, 
               EstimatedMaximum = 200.0m, 
               IsArchived = false, 
               CreatedAt = DateTime.Now 
           };

           // Act
           var auction = await _auctionRepository.GetAuctionByIdAsync(1);

           // Assert
           Assert.Equal(expectedAuction, auction);
       }
   }
}
