using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDTO>> GetPostsAsync()
        {
            var posts = await _postRepository.GetPostsAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task AddPostAsync(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.AddPostAsync(post);
        }

        public async Task UpdatePostAsync(PostDTO postDto)
        {          
            if (postDto.Id == null) return;
            var post = await _postRepository.GetPostByIdAsync((int)postDto.Id);
            if (post == null) return;

            _mapper.Map(postDto, post);
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostsAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null) return;

            await _postRepository.DeletePostAsync(post.Id);
        }
    }
}
