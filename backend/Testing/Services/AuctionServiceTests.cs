// using Xunit;
// using backend.DTOs;
// using AutoMapper;
// using backend.Models;

// namespace backend.Tests
// {
//     public class AuctionServiceTests
//     {
//         // private readonly Mock<IAuctionRepository> _auctionRepositoryMock;
//         private readonly IMapper _mapper;
//         // private readonly AuctionService _auctionService;

//         // public AuctionServiceTests()
//         // {
//         //     _auctionRepositoryMock = new Mock<IAuctionRepository>();
//         //     _mapperMock = new Mock<IMapper>();
//         //     _auctionService = new AuctionService(_auctionRepositoryMock.Object, _mapperMock.Object);
//         // }

//         [Fact]
//         public void AuctionRegistrationDTO_To_Auction_Mapping_Test()
//         {
//             // Arrange
//             var artist = new User
//             {
//                 Bio = "Performance artist based in Poland",
//                 Country = "PL",
//                 Email = "domaukcijny@gmail.com",
//                 FirstName = "Gabi",
//                 LastName = "Zabi Las Vegas",
//                 Id = 420,
//                 Password = "Password exposed in front of underages bois",
//                 PersonalLink = "linkedin.dk/gabizabimiami"
//             };

//             var product = new Product
//             {
//                 Depth = 0,
//                 Height = 0,
//                 Weight = 0,
//                 Width = 0,
//                 Description = "Very nice",
//                 Id = 69,
//                 Title = "plesnivy_kokot_oil_2016",
//                 Artist = artist
//             };

//             var auctionDto = new AuctionRegistrationDTO
//             {
//                 // CreatedAt = new DateTime(2023, 12, 4),
//                 CreatedAt = new DateTime(2023, 12, 4),
//                 EndsAt = new DateTime(2023, 12, 14),
//                 FirstPrice = 100.0,
//                 EstimatedMinimum = 50.0,
//                 EstimatedMaximum = 200.0,
//                 IsArchived = false,
//                 ProductDto = new ProductDTO
//                 {
//                     Depth = product.Depth,
//                     Height = product.Height,
//                     Weight = product.Weight,
//                     Width = product.Width,
//                     Description = product.Description,
//                     Id = product.Id,
//                     Title = product.Title,
//                     Artist = new UserDTO
//                     {
//                         Bio = artist.Bio,
//                         Country = artist.Country,
//                         Email = artist.Email,
//                         FirstName = artist.FirstName,
//                         LastName = artist.LastName,
//                         Id = artist.Id,
//                         Link = "link.com/artist",
//                         Role = UserRole.Admin
//                     }
//                 }
//             };

//             // Act
//             var auction = _mapper.Map<Auction>(auctionDto);

//             // Assert
//             Assert.Equal(auctionDto.CreatedAt, auction.CreatedAt);
//             Assert.Equal(auctionDto.EndsAt, auction.EndsAt);
//             Assert.Equal(auctionDto.FirstPrice, auction.FirstPrice);
//             Assert.Equal(auctionDto.EstimatedMinimum, auction.EstimatedMinimum);
//             Assert.Equal(auctionDto.EstimatedMaximum, auction.EstimatedMaximum);
//             Assert.Equal(auctionDto.IsArchived, auction.IsArchived);
//             Assert.Equal(auctionDto.ProductDto.Id, auction.Product.Id);
//             Assert.Equal(auctionDto.ProductDto.Title, auction.Product.Title);
//             Assert.Equal(auctionDto.ProductDto.Description, auction.Product.Description);
//             Assert.Equal(auctionDto.ProductDto.Artist.Id, auction.Product.Artist.Id);
//             Assert.Equal(auctionDto.ProductDto.Artist.FirstName, auction.Product.Artist.FirstName);
//             Assert.Equal(auctionDto.ProductDto.Artist.LastName, auction.Product.Artist.LastName);
//         }
//     }
//         // public async Task GetAuctions_ReturnsAuctions()
//         // {
//         //     // Arrange
//         //     var expectedAuctions = new List<Auction>
//         //     {
//         //         new() { 
//         //             Id = 1, 
//         //             CreatedAt = DateTime.Now, 
//         //             EndsAt = DateTime.Now.AddDays(7), 
//         //             FirstPrice = 100.0m, 
//         //             EstimatedMinimum = 50.0m, 
//         //             EstimatedMaximum = 200.0m, 
//         //             IsArchived = false, 
//         //             Product = new Product { Id = 1, Title = "Product 1", Height = 10.0m, Width = 20.0m, Depth = 30.0m, Weight = 40.0m, Description = "Description of Product 1", ArtistId = 1 }
//         //         },
//         //         new() { 
//         //             Id = 2, 
//         //             CreatedAt = DateTime.Now, 
//         //             EndsAt = DateTime.Now.AddDays(7), 
//         //             FirstPrice = 200.0m, 
//         //             EstimatedMinimum = 100.0m, 
//         //             EstimatedMaximum = 300.0m, 
//         //             IsArchived = false, 
//         //             Product = new Product { Id = 2, Title = "Product 2", Height = 20.0m, Width = 30.0m, Depth = 40.0m, Weight = 50.0m, Description = "Description of Product 2", ArtistId = 2 }
//         //         }
//         //     };
//         //     var expectedAuctionDTOs = new List<AuctionDTO>
//         //     {
//         //         new() { 
//         //             Id = 1, 
//         //             CreatedAt = DateTime.Now, 
//         //             EndsAt = DateTime.Now.AddDays(7), 
//         //             FirstPrice = 100.0f, 
//         //             EstimatedMinimum = 50.0f, 
//         //             EstimatedMaximum = 200.0f, 
//         //             IsArchived = false, 
//         //             Product = new ProductDTO { Id = 1, Title = "Product 1", Height = 10.0m, Width = 20.0m, Depth = 30.0m, Weight = 40.0m, Description = "Description of Product 1", ArtistId = 1 }
//         //         },
//         //         new() { 
//         //             Id = 2, 
//         //             CreatedAt = DateTime.Now, 
//         //             EndsAt = DateTime.Now.AddDays(7), 
//         //             FirstPrice = 200.0f, 
//         //             EstimatedMinimum = 100.0f, 
//         //             EstimatedMaximum = 300.0f, 
//         //             IsArchived = false, 
//         //             Product = new ProductDTO { Id = 1, Title = "Product 2", Height = 20.0m, Width = 30.0m, Depth = 40.0m, Weight = 50.0m, Description = "Description of Product 2", ArtistId = 2 }
//         //         }
//         //     };
//         //     _auctionRepositoryMock.Setup(ur => ur.GetAuctionsAsync()).ReturnsAsync(expectedAuctions);
//         //     _mapperMock.Setup(m => m.Map<IEnumerable<AuctionDTO>>(It.IsAny<IEnumerable<Auction>>())).Returns(expectedAuctionDTOs);

//         //     // Act
//         //     var auctions = await _auctionService.GetAuctionsAsync();

//         //     // Assert
//         //     Assert.Equal(expectedAuctionDTOs, auctions);
//         // }
//     // }
// }
