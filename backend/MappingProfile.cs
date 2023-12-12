using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionCreationDTO, Auction>();
            CreateMap<AuctionDTO, Auction>();
            CreateMap<Auction, AuctionDTO>();

            CreateMap<UserRegistrationDTO, User>();
            CreateMap<User, UserRegistrationDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<Like, LikeDTO>();
            CreateMap<Picture, PictureDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<Comment, CommentDTO>();

            CreateMap<InstaBuyRegistrationDTO, InstaBuy>();
            CreateMap<InstaBuyDTO, InstaBuy>();
            CreateMap<InstaBuy, InstaBuyDTO>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<UserRegistrationDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<PostRegistrationDTO, Post>();
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();

            CreateMap<PictureRegistrationDTO, Picture>();
            CreateMap<Picture, PictureDTO>();
            CreateMap<PictureDTO, Picture>();

            CreateMap<LikeRegistrationDTO, Like>();         
            CreateMap<Like, LikeDTO>();
            CreateMap<LikeDTO, Like>();

            CreateMap<CommentRegistrationDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }
    }
}
