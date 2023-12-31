using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;

namespace backend.Services
{
    public class PostService(IPostRepository postRepository, IMapper mapper) : IPostService
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<List<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return _mapper.Map<List<PostDTO>>(posts);
        }
        
        public async Task<DbPost> CreatePostAsync(PostCreationDTO postCreationDto)
        {
            postCreationDto.CreatedAt = DateTime.Now;

            DbPost dbPost = await _postRepository.CreatePostAsync(postCreationDto);
            PostDTO postDtoFromDb = _mapper.Map<PostDTO>(dbPost);

            await UpdatePostAsync(postDtoFromDb);

            return dbPost;
        }

        public async Task UpdatePostAsync(PostDTO postDto)
        {          
            var post = await _postRepository.GetPostByIdAsync(postDto.Id);
            if (post == null) return;

            _mapper.Map(postDto, post);
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostsAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null || post.Id == null) return;

            await _postRepository.DeletePostAsync(post.Id);
        }
    }
}
