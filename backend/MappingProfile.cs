using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Auction, AuctionDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Like, LikeDTO>();
            CreateMap<Picture, PictureDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}
