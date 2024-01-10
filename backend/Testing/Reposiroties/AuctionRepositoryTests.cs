// using backend.Data;
// using backend.Data.Models;
// using backend.Enums;
// using backend.Repositories;
// using Xunit;

// namespace Testing.Repositories
// {
//     public class AuctionRepositoryTests(AuctionRepositoryFixture fixture) : IClassFixture<AuctionRepositoryFixture>
//     {
//         private readonly DatabaseContext _context = fixture.Context;
//         private readonly IAuctionRepository _auctionRepository = fixture.AuctionRepository;

//         [Fact]
//         public async Task GetAuctionsAsync_ShouldReturnAuctions()
//         {
//             var auctions = await _auctionRepository.GetAuctionsAsync();

//             Assert.NotNull(auctions);
//             Assert.NotEmpty(auctions);
//         }

//         [Fact]
//         public async Task GetAuctionByIdAsync_ShouldReturnAuction_WhenAuctionExists()
//         {
//             // Arrange
//             var testAuctionId = 1; // Use an ID that exists in the test data

//             // Act
//             var auction = await _auctionRepository.GetAuctionByIdAsync(testAuctionId);

//             // Assert
//             Assert.NotNull(auction);
//             Assert.Equal(testAuctionId, auction.Id);
//         }

//         // Additional tests for CreateAuctionAsync, UpdateAuctionAsync, DeleteAuctionAsync...
//     }
// }
