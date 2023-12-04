using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class PostService(IPostRepository PostRepository, IMapper mapper) : IPostService
    {
        private readonly IPostRepository _postRepository = PostRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _postRepository.GetPostAsync();

            var postDtos = _mapper.Map<IEnumerable<PostDTO>>(posts);

            foreach (var postDto in postDtos)
            {
                var likes = await _postRepository.GetLikesByPostIdAsync(postDto.Id);
                var comments = await _postRepository.GetCommentsByPostIdAsync(postDto.Id);
                var pictures = await _postRepository.GetPicturesByPostIdAsync(postDto.Id);

                postDto.Likes = new List<Like>((IEnumerable<Like>)likes);
                postDto.Comments = new List<Comment>((IEnumerable<Comment>)comments);
                postDto.Pictures = new List<Picture>((IEnumerable<Picture>)pictures);
            }

            return posts;
        }
            
        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var likes = await _postRepository.GetLikesByPostIdAsync(id);
            var comments = await _postRepository.GetCommentsByPostIdAsync(id);
            var pictures = await _postRepository.GetPicturesByPostIdAsync(id);

            var post = await _postRepository.GetPostByIdAsync(id);
            var postDto = _mapper.Map<PostDTO>(post);
            
                postDto.Likes = new List<Like>((IEnumerable<Like>)likes);
                postDto.Comments = new List<Comment>((IEnumerable<Comment>)comments);
                postDto.Pictures = new List<Picture>((IEnumerable<Picture>)pictures);

            return postDto;
        }

        public async Task AddPostAsync(PostDTO PostDto)
        {
            throw new NotImplementedException();
        }   

        public async Task UpdatePostAsync(PostDTO PostDto)
        {
            throw new NotImplementedException();
        }  

        public async Task DeletePostsAsync(int id)
        {
           throw new NotImplementedException();
        }
     }
}
