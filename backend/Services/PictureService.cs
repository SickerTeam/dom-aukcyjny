using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
   public class PictureService(IPictureRepository pictureRepository, IMapper mapper) : IPictureService
    {
        private readonly IPictureRepository _pictureRepository = pictureRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<PictureDTO>> GetPicturesAsync()
        {
            var pictures = await _pictureRepository.GetPicturesAsync();
            return _mapper.Map<IList<PictureDTO>>(pictures);
        }

        public async Task<PictureDTO> GetPicturesByIdAsync(int id)
        {
            var picture = await _pictureRepository.GetPicturesByIdAsync(id);
            return _mapper.Map<PictureDTO>(picture);
        }

        public async Task AddPicturesAsync(PictureRegistrationDTO pictureDto)
        {
            var picture = _mapper.Map<Picture>(pictureDto);
            await _pictureRepository.AddPicturesAsync(picture);
        }

        public async Task DeletePicturesAsync(int id)
        {
            await _pictureRepository.DeletePicturesAsync(id);
        }
    }
}