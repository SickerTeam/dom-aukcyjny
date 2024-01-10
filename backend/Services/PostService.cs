﻿using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class PostService(IPostRepository postRepository, CommentService commentService, LikeService likeService,
        PictureService pictureService, IMapper mapper) : IPostService
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly CommentService _commentService = commentService;
        private readonly LikeService _likeService = likeService;
        private readonly PictureService _pictureService = pictureService;
        private readonly IMapper _mapper = mapper;
        protected internal ModelStateDictionary modelState = new();
        
        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            DbPost post = await _postRepository.GetPostByIdAsync(id);
            PostDTO postDto = _mapper.Map<PostDTO>(post);
            postDto.Comments = await _commentService.GetCommentsByIdAsync(post.Id);
            return postDto;
        }

        public async Task<PostDTO> CreatePostAsync(PostCreationDTO postCreationDto)
        {
            DbPost dbPost = new()
            { 
               UserId = postCreationDto.UserId,
               Text = postCreationDto.Text,
               CreatedAt = DateTime.UtcNow
            };

            DbPost post = await _postRepository.CreatePostAsync(dbPost);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<PostDTO?> UpdatePostAsync(int id, JsonPatchDocument<PostDTO> patchDoc)
        {          
            DbPost post = await _postRepository.GetPostByIdAsync(id);
            if (post == null) return null;

            foreach (var operation in patchDoc.Operations)
            {
                if (operation.path != "text" || operation.op != "replace")
                {
                    throw new InvalidOperationException("Updating one or more fields is not allowed.");
                }
            }

            PostDTO postDto = _mapper.Map<PostDTO>(post);
            patchDoc.ApplyTo(postDto, modelState);

            if (!modelState.IsValid) return null;

            _mapper.Map(postDto, post);
            await _postRepository.UpdatePostAsync(post);

            return _mapper.Map<PostDTO>(post);
        }

        public async Task DeletePostsAsync(int id)
        {
            DbPost post = await _postRepository.GetPostByIdAsync(id);
            if (post == null) return;

            await _postRepository.DeletePostAsync(post);
        }
    }
}
