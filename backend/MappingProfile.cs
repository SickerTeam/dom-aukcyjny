﻿using AutoMapper;
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

            CreateMap<Like, LikeDTO>();
            CreateMap<LikeDTO, Like>();

            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }
    }
}
