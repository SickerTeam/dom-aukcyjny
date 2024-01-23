using AutoMapper;
using backend.Data.Models;
using backend.DTOs;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionCreationDTO, DbAuction>();
            CreateMap<DbAuction, AuctionDTO>();
            CreateMap<AuctionDTO, DbAuction>();

            CreateMap<UserCreationDTO, DbUser>();
            CreateMap<DbUser, UserDTO>();
            CreateMap<UserDTO, DbUser>();

            CreateMap<PostCreationDTO, DbPost>();
            CreateMap<DbPost, PostDTO>();
            CreateMap<PostDTO, DbPost>();

            CreateMap<CommentCreationDTO, DbComment>();
            CreateMap<DbComment, CommentDTO>();
            CreateMap<CommentDTO, DbComment>();

            CreateMap<ProductImageCreationDTO, DbProductImage>();
            CreateMap<DbProductImage, ProductImageDTO>();
            CreateMap<ProductImageDTO, DbProductImage>();

            CreateMap<FixedPriceListingCreationDTO, DbFixedPriceListing>();
            CreateMap<FixedPriceListingDTO, DbFixedPriceListing>();
            CreateMap<DbFixedPriceListing, FixedPriceListingDTO>();

            CreateMap<ProductCreationDTO, DbProduct>();
            CreateMap<DbProduct, ProductDTO>();
            CreateMap<ProductDTO, DbProduct>();

            CreateMap<LikeCreationDTO, DbLike>();         
            CreateMap<DbLike, LikeDTO>();
            CreateMap<LikeDTO, DbLike>();

            CreateMap<BidCreationDTO, DbBid>();         
            CreateMap<DbBid, BidDTO>();
        }
    }
}
