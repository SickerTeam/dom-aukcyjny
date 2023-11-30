using Xunit;
using Moq;
using backend.DTOs;
using backend.Repositories;
using backend.Services;
using AutoMapper;
using backend.Models;

namespace backend.Tests
{
    public class AuctionServiceTests
    {
        private readonly Mock<IAuctionRepository> _auctionRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly AuctionService _auctionService;

        public AuctionServiceTests()
        {
            _auctionRepositoryMock = new Mock<IAuctionRepository>();
            _mapperMock = new Mock<IMapper>();
            _auctionService = new AuctionService(_auctionRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAuctions_ReturnsAuctions()
        {
            // Arrange
            var expectedAuctions = new List<Auction>
            {
                new Auction 
                { 
                    Id = 1, 
                    CreatedAt = DateTime.Now, 
                    EndsAt = DateTime.Now.AddDays(7), 
                    FirstPrice = 100.0m, 
                    EstimatedMinimum = 50.0m, 
                    EstimatedMaximum = 200.0m, 
                    IsArchived = false, 
                    Product = new Product { Id = 1, Title = "Product 1", Height = 10.0m, Width = 20.0m, Depth = 30.0m, Weight = 40.0m, Description = "Description of Product 1", ArtistId = 1 }
                },
                new Auction 
                { 
                    Id = 2, 
                    CreatedAt = DateTime.Now, 
                    EndsAt = DateTime.Now.AddDays(7), 
                    FirstPrice = 200.0m, 
                    EstimatedMinimum = 100.0m, 
                    EstimatedMaximum = 300.0m, 
                    IsArchived = false, 
                    Product = new Product { Id = 2, Title = "Product 2", Height = 20.0m, Width = 30.0m, Depth = 40.0m, Weight = 50.0m, Description = "Description of Product 2", ArtistId = 2 }
                }
            };
            var expectedAuctionDTOs = new List<AuctionDTO>
            {
                new AuctionDTO 
                { 
                    Id = 1, 
                    CreatedAt = DateTime.Now, 
                    EndsAt = DateTime.Now.AddDays(7), 
                    FirstPrice = 100.0f, 
                    EstimatedMinimum = 50.0f, 
                    EstimatedMaximum = 200.0f, 
                    IsArchived = false, 
                    Product = new Product { Id = 1, Title = "Product 1", Height = 10.0m, Width = 20.0m, Depth = 30.0m, Weight = 40.0m, Description = "Description of Product 1", ArtistId = 1 }
                },
                new AuctionDTO 
                { 
                    Id = 2, 
                    CreatedAt = DateTime.Now, 
                    EndsAt = DateTime.Now.AddDays(7), 
                    FirstPrice = 200.0f, 
                    EstimatedMinimum = 100.0f, 
                    EstimatedMaximum = 300.0f, 
                    IsArchived = false, 
                    Product = new Product { Id = 1, Title = "Product 2", Height = 20.0m, Width = 30.0m, Depth = 40.0m, Weight = 50.0m, Description = "Description of Product 2", ArtistId = 2 }
                }
            };
            _auctionRepositoryMock.Setup(ur => ur.GetAuctionsAsync()).ReturnsAsync(expectedAuctions);
            _mapperMock.Setup(m => m.Map<IEnumerable<AuctionDTO>>(It.IsAny<IEnumerable<Auction>>())).Returns(expectedAuctionDTOs);

            // Act
            var auctions = await _auctionService.GetAuctions();

            // Assert
            Assert.Equal(expectedAuctionDTOs, auctions);
        }
    }
}
