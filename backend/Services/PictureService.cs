using AutoMapper;
using backend.DTOs;
using backend.Data.Models;
using backend.Repositories;

namespace backend.Services
{
   public class PictureService(IPictureRepository pictureRepository, IMapper mapper) : IPictureService
   {
        private readonly IPictureRepository _pictureRepository = pictureRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<PictureDTO>> GetPicturesAsync()
        {
            IEnumerable<DbPicture> pictures = await _pictureRepository.GetPictureAsync();
            return _mapper.Map<IList<PictureDTO>>(pictures);
        }

        public async Task<PictureDTO> GetPictureByIdAsync(int id)
        {
            DbPicture picture = await _pictureRepository.GetPicturesByIdAsync(id);
            return _mapper.Map<PictureDTO>(picture);
        }

        public async Task AddPictureAsync(PictureCreationDTO commentDto)
        {
            DbPicture picture = _mapper.Map<DbPicture>(commentDto);
            picture.CreatedAt = DateTime.UtcNow;
            await _pictureRepository.AddPictureAsync(picture);
        }

        public async Task DeletePictureAsync(int id)
        {
            DbPicture picture = await _pictureRepository.GetPicturesByIdAsync(id);
            if (picture == null) return;

            await _pictureRepository.DeletePictureAsync(picture);
        }
    }
}