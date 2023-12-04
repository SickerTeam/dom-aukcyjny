using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
   public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper) : IAuctionService
   {
       private readonly IAuctionRepository _auctionRepository = auctionRepository;
       private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AuctionDTO>> GetAuctionsAsync()
       {
           var auctions = await _auctionRepository.GetAuctionsAsync();
           var auctionDTOs = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
           return auctionDTOs;
       }

       public async Task<AuctionDTO> GetAuctionByIdAsync(int id)
       {
           Auction auction = await _auctionRepository.GetAuctionByIdAsync(id);
           return _mapper.Map<AuctionDTO>(auction);
       }

       public async Task AddAuctionAsync(AuctionRegistrationDTO auctionDto)
       {
           var auction = _mapper.Map<Auction>(auctionDto);
           await _auctionRepository.AddAuctionAsync(auction);
       }  

       public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
       {
           var auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
           if (auction == null) return;

           _mapper.Map(auctionDto, auction);

           await _auctionRepository.UpdateAuctionAsync(auction);
       } 

       public async Task DeleteAuctionsAsync(int id)
       {
           var auction = await _auctionRepository.GetAuctionByIdAsync(id);
           if (auction == null) return;
           if (auction.Id != null)
           {
               await _auctionRepository.DeleteAuctionAsync((int)auction.Id);
           }
       }
   }
}


// using AutoMapper;
// using backend.DTOs;
// using backend.Models;
// using backend.Repositories;

// namespace backend.Services
// {
//     public class AuctionService(IAuctionRepository auctionRepository, IMapper mapper, IProductService productService) : IAuctionService
//     {
//         private readonly IAuctionRepository _auctionRepository = auctionRepository;
//         private readonly IProductService _productService = productService;
//         private readonly IMapper _mapper = mapper;

//         public async Task<IEnumerable<AuctionDTO>> GetAuctionsAsync()
//         {
//             var auctions = await _auctionRepository.GetAuctionsAsync();
//             var auctionDTOs = _mapper.Map<IEnumerable<AuctionDTO>>(auctions);
//             return auctionDTOs;
//         }

//         public async Task<AuctionDTO> GetAuctionByIdAsync(int id)
//         {
//             Auction auction = await _auctionRepository.GetAuctionByIdAsync(id);
//             return _mapper.Map<AuctionDTO>(auction);
//         }

//         public async Task AddAuctionAsync(AuctionRegistrationDTO auctionDto)
//         {
//             var auction = new Auction
//             {
//                 EndsAt = auctionDto.EndsAt,
//                 // Product = _productService.GetProductById(auctionDto.ProductDto.Id);
//                 FirstPrice = (decimal)auctionDto.FirstPrice,
//                 EstimatedMinimum = auctionDto.EstimatedMinimum.HasValue 
//                     ? (decimal)auctionDto.EstimatedMinimum.Value 
//                     : null,
//                 EstimatedMaximum = auctionDto.EstimatedMaximum.HasValue 
//                     ? (decimal)auctionDto.EstimatedMaximum.Value 
//                     : null,
//                 IsArchived = auctionDto.IsArchived,
//                 CreatedAt = auctionDto.CreatedAt,
//             };

//             await _auctionRepository.AddAuctionAsync(auction);
//         }   

//         public async Task UpdateAuctionAsync(AuctionDTO auctionDto)
//         {
//             var auction = await _auctionRepository.GetAuctionByIdAsync(auctionDto.Id);
//             if (auction == null) return;

//             auction.EndsAt = auctionDto.EndsAt;
//             auction.FirstPrice = (decimal)auctionDto.FirstPrice;
//             // auction.Product =  _productService.GetProductById(auctionDto.Product.Id);

//             auction.EstimatedMinimum = auctionDto.EstimatedMinimum.HasValue 
//                 ? (decimal)auctionDto.EstimatedMinimum.Value 
//                 : null;
//             auction.EstimatedMaximum = auctionDto.EstimatedMaximum.HasValue 
//                 ? (decimal)auctionDto.EstimatedMaximum.Value 
//                 : null;
//             auction.IsArchived = auctionDto.IsArchived;
//             auction.CreatedAt = auctionDto.CreatedAt;

//             await _auctionRepository.UpdateAuctionAsync(auction);
//         }  

//         public async Task DeleteAuctionsAsync(int id)
//         {
//             var auction = await _auctionRepository.GetAuctionByIdAsync(id);
//             if (auction == null) return;
//             if (auction.Id != null)
//             {
//                 await _auctionRepository.DeleteAuctionAsync((int)auction.Id);
//             }
//         }
//      }
// }
