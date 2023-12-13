using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionCreationDTO, DbAuction>();
            CreateMap<DbAuction, AuctionDTO>();

            CreateMap<UserCreationDTO, DbUser>();
            CreateMap<DbUser, UserDTO>();

            CreateMap<PostCreationDTO, DbPost>();
            CreateMap<DbPost, PostDTO>();

            CreateMap<CommentCreationDTO, DbComment>();
            CreateMap<DbComment, CommentDTO>();

            CreateMap<FixedPriceListingCreationDTO, DbFixedPriceListing>();
            CreateMap<FixedPriceListingDTO, DbFixedPriceListing>();
            CreateMap<DbFixedPriceListing, FixedPriceListingDTO>();

            CreateMap<ProductCreationDTO, Product>();
            CreateMap<DbProduct, ProductDTO>();

            CreateMap<LikeCreationDTO, DbLike>();         
            CreateMap<DbLike, LikeDTO>();
        }
    }
}
