using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public class PostService(IPostRepository postRepository, IMapper mapper) : IPostService
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IMapper _mapper = mapper;
        
        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            DbPost post = await _postRepository.GetPostByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
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
            if (post == null)
            {
                return null;
            }

            PostDTO postDto = _mapper.Map<PostDTO>(post);
            patchDoc.ApplyTo(postDto);

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
