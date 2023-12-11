using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class PostService(IPostRepository postRepository, IMapper mapper, IUserService userService) : IPostService
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

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

        public async Task AddPostAsync(PostRegistrationDTO postDto)
        {
            // map to model
            var post = _mapper.Map<Post>(postDto);

            // get picture urls - u can access the picture urls directly from the postDto.Pictures, the select is not needed
            var pictureUrls = postDto.Pictures.Select(p => p.PictureUrl).ToList();

            // map additional values
            post.TimePosted = DateTime.Now;

            // make pictures null so the IDs dont conflit when adding later on
            post.Pictures = null;

            // get postId + postDTO from DB
            int postId = await _postRepository.AddPostAsync(post);
            PostDTO postDtoFromDb = await GetPostByIdAsync(postId);

            // Create new PictureDTO list with postId and PictureURLs
            var updatedPictures = new List<PictureDTO>();

            for (int i = 0; i < postDtoFromDb.Pictures.Count; i++) 
            {
                var updatedPicture = new PictureDTO
                {
                    PostId = postId,
                    PictureUrl = pictureUrls[i],
                };
                updatedPictures.Add(updatedPicture);
            }

            // Update pictures in PostDTO
            postDtoFromDb.Pictures = updatedPictures;
            await UpdatePostAsync(postDtoFromDb);
        }

        public async Task UpdatePostAsync(PostDTO postDto)
        {          
            var post = await _postRepository.GetPostByIdAsync((int)postDto.Id);
            if (post == null) return;

            _mapper.Map(postDto, post);
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostsAsync(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null || post.Id == null) return;

            await _postRepository.DeletePostAsync((int)post.Id);
        }
    }
}
